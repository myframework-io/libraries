using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.Http.Exensions;
using Myframework.Libraries.Infra.Log.Contracts;
using Myframework.Libraries.Infra.Log.Options;
using Myframework.Libraries.Infra.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Log.Loggers
{
    public class ExternalHttpErrorLogger : IErrorLogger
    {
        private readonly LogOptions logOptions;
        private readonly IClientTokenManager tokenManager;

        public ExternalHttpErrorLogger(IOptions<LogOptions> logOptions, IClientTokenManager tokenManager)
        {
            this.logOptions = logOptions.Value;
            this.tokenManager = tokenManager;
        }

        public async Task<Result> LogAsync(Exception exception, Guid protocol, string loggedUser, string ipClient, string requestUrl, string httpMethod, HttpContext httpContext = null) =>
            await LogAsync(exception, protocol, loggedUser, ipClient, requestUrl, httpMethod, httpContext, true);

        private async Task<Result> LogAsync(Exception exception, Guid protocol, string loggedUser, string ipClient, string requestUrl, string httpMethod, HttpContext httpContext, bool retryWhen401)
        {
            string token;

            if (logOptions.LogUsingHttpContextAccessToken)
                token = await httpContext.GetTokenAsync("access_token");
            else
            {
                Result<string> resultToken = await tokenManager.GetAccessTokenAsync();

                if (!resultToken.Valid)
                    return resultToken;

                token = resultToken.Value;
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(logOptions.HttpApiErrorLogBaseUrl),
                Timeout = logOptions.HttpApiErrorLogTimeout
            };

            httpClient.DefaultRequestHeaders.Add(Constant.Protocol, protocol.ToString());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request =
                new LogErroRequest
                {
                    User = loggedUser,
                    HttpMethod = httpMethod,
                    RequestUrl = requestUrl,
                    IpClient = ipClient,
                    SourceApplication = logOptions.ApplicationName,
                    SourceServerName = logOptions.ServerName,
                    SourceServerIp = logOptions.ServerIp,
                    Message = exception?.Message,
                    Details = exception?.StackTrace,
                    Type = exception?.GetType().Name,
                    InnerError = MapInnerException(exception?.InnerException)
                };

            Result result = await httpClient.PostJsonResultAsync<LogErroResponse>(logOptions.HttpApiErrorLogRoute, request);

            if (result.ResultCode == (ResultCode)401 && retryWhen401 && !logOptions.LogUsingHttpContextAccessToken)
            {
                Result<string> resultToken = await tokenManager.ResetAccessTokenAsync();

                if (!resultToken.Valid)
                    return resultToken;

                return await LogAsync(exception, protocol, loggedUser, ipClient, requestUrl, httpMethod, httpContext, false);
            }

            return result;
        }

        private LogErroRequest.InnerErrorRequest MapInnerException(Exception innerException)
        {
            if (innerException == null)
                return null;

            return
                new LogErroRequest.InnerErrorRequest
                {
                    Message = innerException?.Message,
                    Details = innerException?.StackTrace,
                    Type = innerException?.GetType().Name,
                    InnerError = MapInnerException(innerException.InnerException)
                };
        }

        [DataContract]
        public class LogErroRequest
        {
            [DataMember] public string User { get; set; }
            [DataMember] public string RequestUrl { get; set; }
            [DataMember] public string HttpMethod { get; set; }
            [DataMember] public string IpClient { get; set; }
            [DataMember] public string SourceApplication { get; set; }
            [DataMember] public string SourceServerName { get; set; }
            [DataMember] public string SourceServerIp { get; set; }
            [DataMember] public string Message { get; set; }
            [DataMember] public string Type { get; set; }
            [DataMember] public string Details { get; set; }
            [DataMember] public InnerErrorRequest InnerError { get; set; }

            [DataContract]
            public class InnerErrorRequest
            {
                [DataMember] public string Message { get; set; }
                [DataMember] public string Type { get; set; }
                [DataMember] public string Details { get; set; }
                [DataMember] public InnerErrorRequest InnerError { get; set; }
            }
        }

        [DataContract]
        public class LogErroResponse
        {

        }
    }
}