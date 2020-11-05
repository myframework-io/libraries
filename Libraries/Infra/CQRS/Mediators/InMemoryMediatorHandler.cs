using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Domain.CQRS.DomainEvent;
using Myframework.Libraries.Infra.CQRS.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.CQRS.Mediators
{
    /// <summary>
    /// Handle em memória responsável por encaminhar o comando para o framework de mediação.
    /// </summary>
    public sealed class InMemoryMediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="mediator"></param>
        public InMemoryMediatorHandler(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// Dispara o comando.
        /// </summary>
        /// <typeparam name="TCommandResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<TCommandResult> DispatchCommandAsync<TCommandResult>(ICommand<TCommandResult> command)
            where TCommandResult : Result
            => await mediator.Send(command);

        /// <summary>
        /// Dispara o evento de domínio.
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public async Task<Result> DispatchDomainEventAsync(IDomainEvent @event)
            => await mediator.Send(@event);
    }
}