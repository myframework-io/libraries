using Myframework.Libraries.Domain.Repositories;
using Myframework.Libraries.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Data
{
    /// <summary>
    /// Classe com implementações básicas para repositórios.
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BaseRepository<TDbContext, TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
        where TDbContext : DbContext
    {
        /// <summary>
        /// Contexto de acesso a dados.
        /// </summary>
        protected readonly TDbContext context;
        private readonly DbSet<TAggregateRoot> entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TDbContext context)
        {
            this.context = context;
            entities = context.Set<TAggregateRoot>();
        }

        /// <summary>
        /// Retorna a entidade filtrando pelo id, carregando as entidades relacinadas no parametro includes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relatedEntitiesToLoad"></param>
        /// <returns></returns>
        public virtual async Task<TAggregateRoot> GetByIdAsync(object id, params Expression<Func<TAggregateRoot, IEnumerable<object>>>[] relatedEntitiesToLoad)
        {
            TAggregateRoot obj = await entities.FindAsync(id);

            if (obj == null)
                return null;

            if (relatedEntitiesToLoad != null)
            {
                foreach (Expression<Func<TAggregateRoot, IEnumerable<object>>> relatedEntityToLoad in relatedEntitiesToLoad)
                {
                    await context.Entry(obj).Collection(relatedEntityToLoad).LoadAsync();
                }
            }

            return obj;
        }

        /// <summary>
        /// Retorna a entidade filtrando pelo id, carregando as entidades relacinadas no parametro includes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relatedEntitiesToLoad"></param>
        /// <returns></returns>
        public virtual TAggregateRoot GetById(object id, params Expression<Func<TAggregateRoot, IEnumerable<object>>>[] relatedEntitiesToLoad)
        {
            TAggregateRoot obj = entities.Find(id);

            if (obj == null)
                return null;

            if (relatedEntitiesToLoad != null)
            {
                foreach (Expression<Func<TAggregateRoot, IEnumerable<object>>> relatedEntityToLoad in relatedEntitiesToLoad)
                {
                    context.Entry(obj).Collection(relatedEntityToLoad).Load();
                }
            }

            return obj;
        }

        /// <summary>
        /// Adiciona a entidade no context para operação de insert
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TAggregateRoot entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null.");

            entities.Add(entity);
        }

        /// <summary>
        /// Altera a entidade no context para operação de update
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TAggregateRoot entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null.");

            context.Update(entity);
        }

        /// <summary>
        /// Remove a entidade do context para operação de delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TAggregateRoot entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null.");

            entities.Remove(entity);
        }
    }
}