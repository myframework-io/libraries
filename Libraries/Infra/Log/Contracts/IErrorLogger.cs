using Myframework.Libraries.Common.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Log.Contracts
{
    /// <summary>
    /// Interface padrão de log de erro.
    /// </summary>
    public interface IErrorLogger
    {
        /// <summary>
        /// Loga o erro.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="protocol"></param>
        /// <param name="loggedUser"></param>
        /// <param name="ipClient"></param>
        /// <param name="requestUrl"></param>
        /// <param name="httpMethod"></param>
        /// <param name="httpContext">Opcional. Usar quando for chamada HTTP.</param>
        Task<Result> LogAsync(Exception exception, Guid protocol, string loggedUser, string ipClient, string requestUrl, string httpMethod, HttpContext httpContext = null);
    }
}