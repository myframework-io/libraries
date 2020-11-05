using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Domain.CQRS.DomainEvent;
using Myframework.Libraries.Infra.CQRS.Commands;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.CQRS.Mediators
{
    /// <summary>
    /// Interface para o mediador de comando e eventos.
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// Dispara o comando.
        /// </summary>
        /// <typeparam name="TCommandResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<TCommandResult> DispatchCommandAsync<TCommandResult>(ICommand<TCommandResult> command)
            where TCommandResult : Result;

        /// <summary>
        /// Dispara o evento de domínio.
        /// </summary>
        /// <param name="@event"></param>
        /// <returns></returns>
        Task<Result> DispatchDomainEventAsync(IDomainEvent @event);
    }
}