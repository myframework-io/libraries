using Dapper;
using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Pagination;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.CQRS.Queries
{
    /// <summary>
    /// Classe com implementações bases para query.
    /// </summary>
    public abstract class BaseQueries : IQueries
    {
        /// <summary>
        /// Executa o count desejado.
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="query">A query a ser executada. Ex: "select count(*) from usuario"</param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(string connString, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            if (string.IsNullOrWhiteSpace(query) || !query.ToLower().Contains("count"))
                throw new ArgumentException("Query parameter cannot be null and must contain a count statement.");

            return await ExecuteScalarAsync<int>(connString, query, param, commandType, commandTimeoutInSeconds);
        }

        /// <summary>
        /// Executa o count desejado.
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="query">A query a ser executada. Ex: "select count(*) from usuario"</param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<long> CountLongAsync(string connString, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            if (string.IsNullOrWhiteSpace(query) || !query.ToLower().Contains("count"))
                throw new ArgumentException("Query parameter cannot be null and must contain a count statement.");

            return await ExecuteScalarAsync<long>(connString, query, param, commandType, commandTimeoutInSeconds);
        }

        /// <summary>
        /// Executa a query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connString"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarAsync<T>(string connString, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<T>(query, param: param, commandType: commandType, commandTimeout: commandTimeoutInSeconds);
            }
        }

        /// <summary>
        /// Executa a query retornando o primeiro registro encontrado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(SqlConnection connection, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null) =>
            await connection.QueryFirstOrDefaultAsync<T>(query, param: param, commandType: commandType, commandTimeout: commandTimeoutInSeconds);

        /// <summary>
        /// Executa a query retornando o primeiro registro encontrado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connString"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string connString, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                return await QueryFirstOrDefaultAsync<T>(connection, query, param: param, commandType, commandTimeoutInSeconds);
            }
        }

        /// <summary>
        /// Executa a query retornando a lista de registros encontrados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryListAsync<T>(SqlConnection connection, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null) =>
            (await connection.QueryAsync<T>(query, param: param, commandType: commandType, commandTimeout: commandTimeoutInSeconds)).ToList();

        /// <summary>
        /// Executa a query retornando a lista de registros encontrados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connString"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryListAsync<T>(string connString, string query, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                return await QueryListAsync<T>(connection, query, param, commandType, commandTimeoutInSeconds);
            }
        }

        /// <summary>
        /// Executa a query retornando a lista paginada de registros encontrados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connString"></param>
        /// <param name="page"></param>
        /// <param name="itensPerPage"></param>
        /// <param name="queryPaged"></param>
        /// <param name="queryCount"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeoutInSeconds"></param>
        /// <returns></returns>
        public async Task<PagedList<T>> QueryPagedAsync<T>(string connString, int page, int itensPerPage, string queryPaged, string queryCount, object param = null, System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeoutInSeconds = null)
        {
            page = NormalizePage(page);
            itensPerPage = NormalizeItensPerPage(itensPerPage);

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                int count = await connection.ExecuteScalarAsync<int>(queryCount, param: param, commandType: commandType, commandTimeout: commandTimeoutInSeconds);
                var itens = (await connection.QueryAsync<T>(queryPaged, param: param)).ToList();

                return new PagedList<T>(itens, page, count, itensPerPage);
            }
        }

        /// <summary>
        /// Normaliza a clausula where. Usado para quando estiver criando composição onde cláusular começam com "and".
        /// Usar em conjuno com os métodos ComposeWhere.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        protected string NormalizeWhereClause(string where)
        {
            if (!where.IsNullOrWhiteSpace())
            {
                where = where.TrimStart();

                if (where.ToLower().StartsWith("and "))
                    where = where.Substring("and ".Length);

                where = "where " + where;
            }

            return where;
        }

        #region Obsolete

        /// <summary>
        /// Compõe uma clásula where e adiciona o parametro à lista de parametros da query. Ex: " and u.Name = @name ".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="aliasAndField"></param>
        /// <param name="paramName"></param>
        /// <param name="conditionType"></param>
        /// <param name="operationType"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [Obsolete("Usar a sobrecarga que usa o 'DynamicParameters', pois possui uma performance melhor.")]
        protected string ComposeWhereClause(dynamic parameters, object param, string aliasAndField, string paramName, string conditionType = "and", string operationType = "=", Func<bool> func = null)
        {
            if (func == null)
                func = () => param != null && param.GetType() == typeof(string) ? !((string)param).IsNullOrWhiteSpace() : param != null;

            return ComposeWhereClauseBase(parameters, param, aliasAndField, paramName, conditionType, operationType, func);
        }

        /// <summary>
        /// Compõe uma clásula where filtrando um determinado parametro entre e dois campos de uma tabela. Ex: " paramName like aliasAndFieldBetweenFirstValue and isNull(aliasAndFieldBetweenLastValue, paramName)".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="paramName"></param>
        /// <param name="aliasAndFieldBetweenFirstValue"></param>
        /// <param name="aliasAndFieldBetweenLastValue"></param>
        /// <param name="conditionType"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [Obsolete("Usar a sobrecarga que usa o 'DynamicParameters', pois possui uma performance melhor.")]
        protected string ComposeWhereClauseBetween(dynamic parameters, object param, string paramName, string aliasAndFieldBetweenFirstValue, string aliasAndFieldBetweenLastValue, string conditionType = "and", Func<bool> func = null)
        {
            if (func == null)
                func = () => param != null && param.GetType() == typeof(string) ? !((string)param).IsNullOrWhiteSpace() : param != null;

            string where = "";

            if (func())
            {
                where += $" {conditionType} @{paramName} between {aliasAndFieldBetweenFirstValue} and isNull({aliasAndFieldBetweenLastValue}, @{paramName})";

                var paramDic = parameters as IDictionary<string, object>;

                if (paramDic.ContainsKey(paramName))
                    paramDic[paramName] = param;
                else
                    paramDic.Add(paramName, param);
            }

            return where;
        }

        /// <summary>
        /// Compõe uma clásula where e adiciona o parametro à lista de parametros da query. Ex: " and u.Name = @name ".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="aliasAndField"></param>
        /// <param name="paramName"></param>
        /// <param name="conditionType"></param>
        /// <param name="operationType"></param>
        /// <param name="hasValueFunction"></param>
        /// <returns></returns>
        [Obsolete("Usar a sobrecarga que usa o 'DynamicParameters', pois possui uma performance melhor.")]
        protected string ComposeWhereClauseBase(dynamic parameters, object param, string aliasAndField, string paramName, string conditionType, string operationType, Func<bool> hasValueFunction)
        {
            string where = "";

            if (hasValueFunction())
            {
                if (operationType?.Trim().ToLower() == "like")
                    where += $" {conditionType} {aliasAndField} {operationType} CONCAT('%',@{paramName},'%')";
                else
                    where += $" {conditionType} {aliasAndField} {operationType} @{paramName}";

                var paramDic = parameters as IDictionary<string, object>;

                if (paramDic.ContainsKey(paramName))
                    paramDic[paramName] = param;
                else
                    paramDic.Add(paramName, param);
            }

            return where;
        }

        #endregion Obsolete

        /// <summary>
        /// Compõe uma clásula where e adiciona o parametro à lista de parametros da query. Ex: " and u.Name = @name ".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="aliasAndField"></param>
        /// <param name="paramName"></param>
        /// <param name="conditionType"></param>
        /// <param name="operationType"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        protected string ComposeWhereClause(DynamicParameters parameters, object param, string aliasAndField, string paramName, string conditionType = "and", string operationType = "=", Func<bool> func = null)
        {
            if (func == null)
                func = () => param != null && param.GetType() == typeof(string) ? !((string)param).IsNullOrWhiteSpace() : param != null;

            return ComposeWhereClauseBase(parameters, param, aliasAndField, paramName, conditionType, operationType, func);
        }

        /// <summary>
        /// Compõe uma clásula where filtrando um determinado parametro entre e dois campos de uma tabela. Ex: " paramName like aliasAndFieldBetweenFirstValue and isNull(aliasAndFieldBetweenLastValue, paramName)".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="paramName"></param>
        /// <param name="aliasAndFieldBetweenFirstValue"></param>
        /// <param name="aliasAndFieldBetweenLastValue"></param>
        /// <param name="conditionType"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        protected string ComposeWhereClauseBetween(DynamicParameters parameters, object param, string paramName, string aliasAndFieldBetweenFirstValue, string aliasAndFieldBetweenLastValue, string conditionType = "and", Func<bool> func = null)
        {
            if (func == null)
                func = () => param != null && param.GetType() == typeof(string) ? !((string)param).IsNullOrWhiteSpace() : param != null;

            string where = "";

            if (func())
            {
                where += $" {conditionType} @{paramName} between {aliasAndFieldBetweenFirstValue} and isNull({aliasAndFieldBetweenLastValue}, @{paramName})";
                parameters.Add(paramName, param);
            }

            return where;
        }

        /// <summary>
        /// Compõe uma clásula where e adiciona o parametro à lista de parametros da query. Ex: " and u.Name = @name ".
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="param"></param>
        /// <param name="aliasAndField"></param>
        /// <param name="paramName"></param>
        /// <param name="conditionType"></param>
        /// <param name="operationType"></param>
        /// <param name="hasValueFunction"></param>
        /// <returns></returns>
        protected string ComposeWhereClauseBase(DynamicParameters parameters, object param, string aliasAndField, string paramName, string conditionType, string operationType, Func<bool> hasValueFunction)
        {
            string where = "";

            if (hasValueFunction())
            {
                if (operationType?.Trim().ToLower() == "like")
                    where += $" {conditionType} {aliasAndField} {operationType} CONCAT('%',@{paramName},'%')";
                else
                    where += $" {conditionType} {aliasAndField} {operationType} @{paramName}";

                parameters.Add(paramName, param);
            }

            return where;
        }

        /// <summary>
        /// Normaliza a página, garantindo que não seja negativa.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="defaultPage"></param>
        /// <returns></returns>
        protected int NormalizePage(int page, int defaultPage = 0)
        {
            if (page < 0)
                return defaultPage;

            return page;
        }

        /// <summary>
        /// Normaliza os itens por página para garantir que não seja negativo e nem excessivo.
        /// </summary>
        /// <param name="itensPerPage"></param>
        /// <param name="defaultItensPerPage"></param>
        /// <param name="maxItensPerpage"></param>
        /// <returns></returns>
        protected int NormalizeItensPerPage(int itensPerPage, int defaultItensPerPage = 10, int maxItensPerpage = 100)
        {
            if (itensPerPage <= 0)
                return defaultItensPerPage;

            if (itensPerPage > maxItensPerpage)
                return maxItensPerpage;

            return itensPerPage;
        }
    }
}