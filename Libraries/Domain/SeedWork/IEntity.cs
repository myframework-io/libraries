using Myframework.Libraries.Domain.CQRS.DomainEvent;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Domain.SeedWork
{
    public interface IEntity
    {
        /// <summary>
        /// Eventos de domínio cadsatrados.
        /// </summary>
        [IgnoreDataMember, System.Text.Json.Serialization.JsonIgnore]
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        /// <summary>
        /// Adiciona um evento de domínio à entidade.
        /// </summary>
        /// <param name="eventItem"></param>
        void AddDomainEvent(IDomainEvent eventItem);

        /// <summary>
        /// Remove o evento de domínio.
        /// </summary>
        /// <param name="eventItem"></param>
        void RemoveDomainEvent(IDomainEvent eventItem);

        /// <summary>
        /// Zera a lista de eventos de domínio.
        /// </summary>
        void ClearDomainEvents();
    }
}