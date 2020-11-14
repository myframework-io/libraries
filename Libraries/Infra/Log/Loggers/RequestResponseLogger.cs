//using Myframework.Libraries.Common.Constants;
//using Myframework.Libraries.Common.Helpers;
//using Myframework.Libraries.Infra.Log.Contracts;
//using Myframework.Libraries.Infra.Log.Models;
//using Myframework.Libraries.Infra.Log.Options;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Extensions;
//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.Extensions.Options;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Myframework.Libraries.Infra.Log.Loggers
//{
//    /// <summary>
//    /// Logger padrão de request e response.
//    /// </summary>
//    public class RequestResponseLogger : IRequestResponseLogger
//    {
//        private readonly ILogRequestService logService;

//        /// <summary>
//        /// Construtor padrão.
//        /// </summary>
//        /// <param name="logService"></param>
//        /// <param name="logOptions"></param>
//        public RequestResponseLogger(ILogRequestService logService, IOptions<LogOptions> logOptions)
//        {
//            if (logOptions?.Value == null)
//                throw new ArgumentException("Log options is required.");

//            LogOptions = logOptions.Value;
//            this.logService = logService;
//        }

//        /// <summary></summary>
//        public LogOptions LogOptions { get; private set; }

//        /// <summary></summary>
//        public async Task Logar(HttpContext context, DateTime requestTime, DateTime responseTime, string requestBodyText, string responseBodyText, long responseTimeMs)
//        {
//            if (context?.Response?.Headers != null && context.Response.Headers.ContainsKey(Constant.IgnoreRequestResponseLog))
//            {
//                context.Response.Headers.Remove(Constant.IgnoreRequestResponseLog);
//                return;
//            }

//            if (!LogOptions.EnableLogRequest)
//                return;

//            LogRequest log = MapLogRequisicao(context, requestTime, responseTime, requestBodyText, responseBodyText, responseTimeMs);

//            if (LogOptions.LogRequestsInBackground)
//#pragma warning disable CS4014 // Removendo warning do visual studio pois pode ser chamado sincronamente
//                logService.LogRequestAsync(log);
//#pragma warning restore CS4014 // Removendo warning do visual studio pois pode ser chamado sincronamente
//            else
//                await logService.LogRequestAsync(log);
//        }

//        private LogRequest MapLogRequisicao(HttpContext context, DateTime requestTime, DateTime responseTime, string requestBodyText, string responseBodyText, long responseTimeMs)
//        {
//            requestBodyText = JsonHelper.RemoveSensitiveData(requestBodyText, LogOptions.SensitiveProperties);

//            string ipCliente = context.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();

//            string ipOrigemHeader = context.Request.Headers[Constant.SourceIp].ToString();

//            if (!string.IsNullOrWhiteSpace(ipOrigemHeader))
//                ipCliente = ipOrigemHeader;

//            string protocoloStr = context.Request.Headers[Constant.Protocol].ToString();

//            if (!Guid.TryParse(protocoloStr, out Guid protocol))
//                protocol = Guid.Empty;

//            string requestedUri = UriHelper.GetDisplayUrl(context.Request);

//            var uri = new Uri(requestedUri);
//            string hostUrl = uri.GetComponents(UriComponents.Scheme | UriComponents.Host | UriComponents.Port, UriFormat.UriEscaped);
//            string urlPath = uri.GetComponents(UriComponents.PathAndQuery, UriFormat.UriEscaped);

//            var log = new LogRequest
//            {
//                Id = Guid.NewGuid(),
//                ClientIP = ipCliente,
//                UrlHost = hostUrl,
//                UrlPath = urlPath,

//                RequestBody = requestBodyText,
//                RequestContentType = context.Request.ContentType,
//                RequestMethod = context.Request.Method,
//                RequestHeaders = SerializarHeaders(context.Request.Headers),
//                RequestDate = requestTime,

//                ResponseBody = responseBodyText,
//                ResponseContentType = context.Response.ContentType,
//                ResponseHeaders = SerializarHeaders(context.Response.Headers),
//                ResponseDate = responseTime,
//                ResponseStatusCode = context.Response.StatusCode,
//                ResponseTimeMs = responseTimeMs,

//                Protocol = protocol,
//                Tags = null,

//                IdEntidade = GetPropertyIdsFromOptions(requestBodyText),
//                CustomData = GetCustomData(),
//            };

//            return log;
//        }

//        /// <summary>
//        /// Obtém o identificador de entidade. Sobrescreva o método para customizar a obtenção de identificador de entidade.
//        /// </summary>
//        /// <returns></returns>
//        protected virtual string GetPropertyIdsFromOptions(string json)
//        {
//            if (LogOptions.PropertiesIds == null || !LogOptions.PropertiesIds.Any())
//                return null;

//            bool jsonValido = JsonHelper.CheckIfJsonIsValid(json);

//            if (string.IsNullOrWhiteSpace(json) || json.StartsWith("***") || !jsonValido)
//                return json;

//            dynamic dynObj = JsonConvert.DeserializeObject(json);

//            var jObj = (JObject)dynObj;

//            if (jObj == null)
//                return json;

//            var propriedades = LogOptions.PropertiesIds.Where(it => !string.IsNullOrWhiteSpace(it)).Select(it => it.ToLower()).ToList();

//            return ExtractIdProperty(jObj.Children(), propriedades);
//        }

//        /// <summary>
//        /// Obtém dados customizados. Sobrescreva o método para customizar a obtenção.
//        /// </summary>
//        /// <returns></returns>
//        protected virtual string GetCustomData() => null;

//        private string SerializarHeaders(IHeaderDictionary headers)
//        {
//            var dic = new Dictionary<string, string>();

//            foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> kvp in headers.ToList())
//            {
//                dic.Add(kvp.Key, kvp.Value.ToString());
//            }

//            return JsonConvert.SerializeObject(dic, Formatting.Indented);
//        }

//        private string ExtractIdProperty(IEnumerable<JToken> children, List<string> propriedadesIdEntidade)
//        {
//            if (!children.Any())
//                return null;

//            foreach (JToken token in children)
//            {
//                var prop = (JProperty)token;

//                if (prop == null)
//                    continue;

//                if (prop.Value != null && prop.Value.Type == JTokenType.Object)
//                {
//                    string idEntidade = ExtractIdProperty(prop.Value.Children(), propriedadesIdEntidade);

//                    if (!string.IsNullOrWhiteSpace(idEntidade))
//                        return idEntidade;
//                }
//                else
//                {
//                    if (propriedadesIdEntidade.Contains(prop.Name.ToLower()))
//                        return prop.Value.ToString();
//                }
//            }

//            return null;
//        }
//    }
//}