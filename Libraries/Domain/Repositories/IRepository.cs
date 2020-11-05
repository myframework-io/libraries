using Myframework.Libraries.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Myframework.Libraries.Domain.Repositories
{
    /// <summary>
    /// Repositório base para raízes de agregado.
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Retorna a entidade filtrando pelo id, carregando as entidades relacinadas no parametro includes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relatedEntitiesToLoad"></param>
        /// <returns></returns>
        Task<TAggregateRoot> GetByIdAsync(object id, params Expression<Func<TAggregateRoot, IEnumerable<object>>>[] relatedEntitiesToLoad);

        /// <summary>
        /// Retorna a entidade filtrando pelo id, carregando as entidades relacinadas no parametro includes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relatedEntitiesToLoad"></param>
        /// <returns></returns>
        TAggregateRoot GetById(object id, params Expression<Func<TAggregateRoot, IEnumerable<object>>>[] relatedEntitiesToLoad);

        /// <summary>
        /// Adiciona a entidade no context para operação de insert
        /// </summary>
        /// <param name="entity"></param>
        void Add(TAggregateRoot entity);

        /// <summary>
        /// Altera a entidade no context para operação de update
        /// </summary>
        /// <param name="entity"></param>
        void Update(TAggregateRoot entity);

        /// <summary>
        /// Remove a entidade do context para operação de delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TAggregateRoot entity);
    }
}