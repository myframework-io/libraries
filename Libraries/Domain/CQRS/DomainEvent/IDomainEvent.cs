using Myframework.Libraries.Common.Results;
using MediatR;
using System;

namespace Myframework.Libraries.Domain.CQRS.DomainEvent
{
    /// <summary>
    /// Interface para eventos de domínio que especifica um retorno genérico.
    /// </summary>
    public interface IDomainEvent : IRequest<Result>
    {
        /// <summary>
        /// Protocolo do evento.
        /// </summary>
        Guid Protocol { get; set; }
    }
}