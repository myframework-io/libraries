using Myframework.Libraries.Infra.Log.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Log.Contracts
{
    /// <summary>
    /// Logger para request/response.
    /// </summary>
    public interface IRequestResponseLogger
    {
        /// <summary>
        /// 
        /// </summary>
        LogOptions LogOptions { get; }

        /// <summary>
        /// 
        /// </summary>
        Task Logar(HttpContext context, DateTime requestTime, DateTime responseTime, string requestBodyText, string responseBodyText, long responseTimeMs);
    }
}