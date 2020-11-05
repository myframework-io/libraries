using System;

namespace Myframework.Libraries.Domain.CQRS.DomainEvent
{
    /// <summary>
    /// Classe base para eventos de domínio que tem resultado (Result).
    /// </summary>
    public abstract class BaseDomainEvent : IDomainEvent
    {
        /// <summary>
        /// Protocolo do comando.
        /// </summary>
        public Guid Protocol { get; set; } = Guid.NewGuid();
    }
}