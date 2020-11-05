using Myframework.Libraries.Domain.CQRS.DomainEvent;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Domain.SeedWork
{
    /// <summary>
    /// Classe base para entidades.
    /// </summary>
    public abstract class Entity : IEntity
    {
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        /// <summary>
        /// Eventos de domínio cadsatrados.
        /// </summary>
        [IgnoreDataMember, System.Text.Json.Serialization.JsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

        /// <summary>
        /// Adiciona um evento de domínio à entidade.
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(IDomainEvent eventItem) => domainEvents.Add(eventItem);

        /// <summary>
        /// Remove o evento de domínio.
        /// </summary>
        /// <param name="eventItem"></param>
        public void RemoveDomainEvent(IDomainEvent eventItem) => domainEvents?.Remove(eventItem);

        /// <summary>
        /// Zera a lista de eventos de domínio.
        /// </summary>
        public void ClearDomainEvents() => domainEvents.Clear();

        /// <summary>
        /// Verifica se essa instância é igual a outra.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;

            return base.Equals(obj);
        }

        /// <summary>
        /// Retorna o hash do objeto.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Verifica se as entidades são a mesmas.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity left, Entity right)
        {
            if (object.Equals(left, null))
                return (object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        /// <summary>
        /// Verifica se as entidades são diferentes.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}