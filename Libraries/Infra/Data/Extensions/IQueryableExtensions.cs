using Myframework.Libraries.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Data.Extensions
{
    /// <summary>
    /// Extension para IQueryable.
    /// </summary>
    public static class IQueryableExtensions
    {
        internal static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();
        internal static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
        internal static readonly FieldInfo QueryModelGeneratorField = typeof(QueryCompiler).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryModelGenerator");
        internal static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
        internal static readonly PropertyInfo DatabaseDependenciesField = typeof(DbLoggerCategory.Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");


        /// <summary>
        /// Faz o processo de paginação (e count) sobre a query informada.
        /// </summary>
        /// <param name="query">Query na qual será aplicada a paginação.</param>
        /// <param name="order">Expressão lambda para ordenação. Campo obrigatório para paginar. Exemplo: (e => e.Id)</param>
        /// <param name="page">Numero da pagina.</param>
        /// <param name="itensPerPage">Registros por pagina.</param>
        /// <param name="orderAscending">Ordenação crescente (true) ou decrescente (false).</param>
        public static PagedList<T> ToPagedList<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> order, int page, int itensPerPage, bool orderAscending = true)
        {
            if (page < 0)
                page = 0;

            if (itensPerPage <= 0)
                itensPerPage = 1;

            IOrderedQueryable<T> orderQuery = orderAscending ? query.OrderBy(order) : query.OrderByDescending(order);

            int totalItens = query.Count();
            var itens = orderQuery.Skip(itensPerPage * page).Take(itensPerPage).ToList();

            return new PagedList<T>(itens, page, totalItens, itensPerPage);
        }

        /// <summary>
        /// Faz o processo de paginação (e count) sobre a query informada.
        /// </summary>
        /// <param name="query">Query na qual será aplicada a paginação.</param>
        /// <param name="order">Expressão lambda para ordenação. Campo obrigatório para paginar. Exemplo: (e => e.Id)</param>
        /// <param name="page">Numero da pagina.</param>
        /// <param name="itensPerPage">Registros por pagina.</param>
        /// <param name="orderAscending">Ordenação crescente (true) ou decrescente (false).</param>
        public static async Task<PagedList<T>> ToPagedListAsync<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> order, int page, int itensPerPage, bool orderAscending = true)
        {
            if (page < 0)
                page = 0;

            if (itensPerPage <= 0)
                itensPerPage = 1;

            IOrderedQueryable<T> orderQuery = orderAscending ? query.OrderBy(order) : query.OrderByDescending(order);

            Task<int> taskCount = query.CountAsync();
            Task<System.Collections.Generic.List<T>> taskList = orderQuery.Skip(itensPerPage * page).Take(itensPerPage).ToListAsync();

            await Task.WhenAll(taskCount, taskList);

            int totalItens = taskCount.Result;
            System.Collections.Generic.List<T> itens = taskList.Result;

            return new PagedList<T>(itens, page, totalItens, itensPerPage);
        }

        /// <summary>
        /// Faz o processo de paginação (e count) sobre a query informada.
        /// </summary>
        /// <param name="query">Query na qual será aplicada a paginação.</param>
        /// <param name="page">Numero da pagina.</param>
        /// <param name="itensPerPage">Registros por pagina.</param>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int page, int itensPerPage)
        {
            if (page < 0)
                page = 0;

            if (itensPerPage <= 0)
                itensPerPage = 1;

            Task<int> taskCount = query.CountAsync();
            Task<System.Collections.Generic.List<T>> taskList = query.Skip(itensPerPage * page).Take(itensPerPage).ToListAsync();

            await Task.WhenAll(taskCount, taskList);

            int totalItens = taskCount.Result;
            System.Collections.Generic.List<T> itens = taskList.Result;

            return new PagedList<T>(itens, page, totalItens, itensPerPage);
        }
    }
}