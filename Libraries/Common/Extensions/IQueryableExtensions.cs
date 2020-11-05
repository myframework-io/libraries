using Myframework.Libraries.Common.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para IQueryable.
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Realiza a paginação sobre a query informada e retorna um <c>PagedList</c> com os dados paginados e informações como total de páginas, total de itens e etc.
        /// </summary>
        /// <param name="query">Query na qual será aplicada a paginação.</param>
        /// <param name="order">Expressão para ordenação. Exemplo: (it => it.Id)</param>
        /// <param name="page">Numero da pagina.</param>
        /// <param name="itensPerPage">Quantidade de registros por pagina.</param>
        /// <param name="orderAscending">Ordenação ascendente (true) ou descendente (false).</param>
        public static PagedList<T> ToPagedList<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> order, int page, int itensPerPage, bool orderAscending = true)
        {
            if (query == null)
                return null;

            if (page < 0)
                page = 0;

            if (itensPerPage <= 0)
                itensPerPage = 1;

            IOrderedQueryable<T> queryPaged = orderAscending ? query.OrderBy(order) : query.OrderByDescending(order);
            var itens = queryPaged.Skip(itensPerPage * page).Take(itensPerPage).ToList();
            int totalItems = query.Count();

            return new PagedList<T>(itens, page, totalItems, itensPerPage);
        }
    }
}