using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Domain.SeedWork;
using Myframework.Libraries.Infra.CQRS.Mediators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Data
{
    /// <summary>
    /// Implementação base do UnitOfWork que dispara eventos de domínios antes de salvar as alterações no banco.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseUnitOfWork<T> : IUnitOfWork
        where T : DbContext
    {
        /// <summary>
        /// Contexto do EF.
        /// </summary>
        protected readonly T context;

        /// <summary>
        /// Mediador que dispara comandos e eventos.
        /// </summary>
        protected readonly IMediatorHandler mediatorHandler;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mediatorHandler"></param>
        public BaseUnitOfWork(T context, IMediatorHandler mediatorHandler)
        {
            this.context = context;
            this.mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Habilita ou desabilita o auto detect.
        /// </summary>
        public virtual bool AutoDetectChangesEnabled
        {
            get => context.ChangeTracker.AutoDetectChangesEnabled;
            set => context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

        /// <summary>
        /// Libera os recursos da instância.
        /// </summary>
        public virtual void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

        /// <summary>
        /// Dispara eventos e salva em seguida, de forma síncrona.
        /// </summary>
        /// <returns></returns>
        public virtual Result SaveChanges()
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            Result result = DispatchDomainEventsAsync().GetAwaiter().GetResult();

            if (!result.Valid)
                return result;

            context.SaveChanges();

            return result;
        }

        /// <summary>
        /// Dispara eventos e salva em seguida, de forma assíncrona.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Result result = await DispatchDomainEventsAsync();

            if (!result.Valid)
                return result;

            await context.SaveChangesAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Dispara os eventos de domínio.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task<Result> DispatchDomainEventsAsync()
        {
            var result = new Result();

            IEnumerable<EntityEntry<IEntity>> domainEntities = context.ChangeTracker
                .Entries<IEntity>()
                .Where(it => it.Entity.DomainEvents != null && it.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(it => it.Entity.DomainEvents)
                .ToList();

            if (!domainEvents.Any())
                return result;

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents.Select(domainEvent => mediatorHandler.DispatchDomainEventAsync(domainEvent)).ToList();

            await Task.WhenAll(tasks);

            var tasksResultsNotValid = tasks
                .Where(it => !it.Result.Valid)
                .Select(it => it.Result)
                .ToList();

            if (!tasksResultsNotValid.Any())
                return result;

            if (tasksResultsNotValid.Any(it => (int)it.ResultCode >= 500))
            {
                var errorMsgs = tasksResultsNotValid.Where(it => (int)it.ResultCode >= 500).Select(it => it.Message).ToList();
                return result.Set(ResultCode.GenericError, errorMsgs.JoinListInSingleString("\r\n"));
            }

            var msgs = tasksResultsNotValid.Select(it => it.Message).ToList();
            return result.Set(ResultCode.GenericError, msgs.JoinListInSingleString("\r\n"));
        }
    }
}