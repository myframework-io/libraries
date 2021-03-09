using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Enums;
using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.Http.Client.ContentsGenerators;
using Myframework.Libraries.Infra.Http.Client.HttpResponseToResultDeserializers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Http.Exensions
{
    /// <summary>
    /// Extensões para o HttpClient.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Realiza um PING para a url informada. Por ser um PING, é usado somente a informação do host da URL para fazer o PING.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IPStatus Ping(this HttpClient httpClient, string url)
        {
            var uri = new Uri(url);
            string hostUrl = uri.GetComponents(UriComponents.Host, UriFormat.UriEscaped);

            PingReply result = new Ping().Send(hostUrl);
            return result.Status;
        }

        /// <summary>
        /// Faz uma requisição do tipo GET, serializando o request informado e deserializando a resposta em um Result.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="queryStringObject">Objeto que será transformado em query string. Use null caso não deseje passar parâmetros via query string.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> GetResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object queryStringObject, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            requestUri = await CreateUriWithParamsFromRequestAsync(requestUri, queryStringObject);
            return await SendHttpRequestAsync<TResponse>(httpClient, HttpVerb.Get, requestUri, null, headers);
        }

        /// <summary>
        /// Faz uma requisição do tipo POST, serializando o request informado e deserializando a resposta em um Result.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="httpContentGenerator">O tipo de gerador do conteúdo Http. Exemplo: json, xml, etc.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> PostResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object bodyObject, IHttpContentGenerator httpContentGenerator, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            HttpContent content = httpContentGenerator.GenerateContent(bodyObject);
            return await SendHttpRequestAsync<TResponse>(httpClient, HttpVerb.Post, requestUri, content, headers);
        }

        /// <summary>
        /// Faz uma requisição do tipo POST, serializando o request informado e deserializando a resposta em um Result, usando JSON.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> PostJsonResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object bodyObject, Dictionary<string, string> headers = null)
            where TResponse : class, new() => await PostResultAsync<TResponse>(httpClient, requestUri, bodyObject, new JsonContentGenerator(), headers);

        /// <summary>
        /// Faz uma requisição do tipo POST, serializando o request informado e deserializando a resposta em um Result, usando JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result> PostJsonResultAsync(this HttpClient httpClient, string requestUri, object bodyObject, Dictionary<string, string> headers = null) => 
            await PostResultAsync<EmptyResponse>(httpClient, requestUri, bodyObject, new JsonContentGenerator(), headers);

        /// <summary>
        /// Faz uma requisição do tipo PUT, serializando o request informado e deserializando a resposta em um Result.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="httpContentGenerator"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> PutResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object bodyObject, IHttpContentGenerator httpContentGenerator, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            HttpContent content = httpContentGenerator.GenerateContent(bodyObject);
            return await SendHttpRequestAsync<TResponse>(httpClient, HttpVerb.Put, requestUri, content, headers);
        }

        /// <summary>
        /// Faz uma requisição do tipo PUT, serializando o request informado e deserializando a resposta em um Result, usando JSON.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> PutJsonResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object bodyObject, Dictionary<string, string> headers = null) where TResponse : class, new() =>
            await PutResultAsync<TResponse>(httpClient, requestUri, bodyObject, new JsonContentGenerator(), headers);

        /// <summary>
        /// Faz uma requisição do tipo PUT, serializando o request informado e deserializando a resposta em um Result, usando JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="bodyObject">Objeto que será serializado para envio no body da requisição.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result> PutJsonResultAsync(this HttpClient httpClient, string requestUri, object bodyObject, Dictionary<string, string> headers = null) =>
            await PutResultAsync<EmptyResponse>(httpClient, requestUri, bodyObject, new JsonContentGenerator(), headers);

        /// <summary>
        /// Faz uma requisição do tipo DELETE, serializando o request informado e deserializando a resposta em um Result.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="queryStringObject">Objeto que será transformado em query string. Use null caso não deseje passar parâmetros via query string.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result<TResponse>> DeleteResultAsync<TResponse>(this HttpClient httpClient, string requestUri, object queryStringObject, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            requestUri = await CreateUriWithParamsFromRequestAsync(requestUri, queryStringObject);
            return await SendHttpRequestAsync<TResponse>(httpClient, HttpVerb.Delete, requestUri, null, headers);
        }

        /// <summary>
        /// Faz uma requisição do tipo DELETE, serializando o request informado e deserializando a resposta em um Result.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="queryStringObject">Objeto que será transformado em query string. Use null caso não deseje passar parâmetros via query string.</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<Result> DeleteResultAsync(this HttpClient httpClient, string requestUri, object queryStringObject, Dictionary<string, string> headers = null)
        {
            requestUri = await CreateUriWithParamsFromRequestAsync(requestUri, queryStringObject);
            return await SendHttpRequestAsync<EmptyResponse>(httpClient, HttpVerb.Delete, requestUri, null, headers);
        }

        #region Privates

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="verb"></param>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private static async Task<Result<TResponse>> SendHttpRequestAsync<TResponse>(HttpClient httpClient, HttpVerb verb, string requestUri, HttpContent content, Dictionary<string, string> headers)
            where TResponse : class, new()
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    if (!string.IsNullOrEmpty(kvp.Value))
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation(kvp.Key, kvp.Value);
                }
            }

            Result<TResponse> result;

            try
            {
                HttpResponseMessage httpResponse = await SendAsync(httpClient, verb, requestUri, content);

                result = await GenerateResultFromHttpResponseAsync<TResponse>(httpResponse);

                UpdateResultStatusFromHttpResponse(result, httpResponse);

            }
            catch (HttpRequestException hexc)
            {
                result = new Result<TResponse>();
                result.Set((ResultCode)503, $"Communication error of type 'HttpRequestException'. Details: {hexc.ToString().SubstringIfMaxLength(1800)}");
            }
            catch (CommunicationException cexc)
            {
                result = new Result<TResponse>();
                result.Set((ResultCode)503, $"Communication error of type 'CommunicationException'. Details: {cexc.ToString().SubstringIfMaxLength(1800)}");
            }

            return result;
        }

        private static async Task<HttpResponseMessage> SendAsync(HttpClient httpClient, HttpVerb verb, string requestUri, HttpContent content)
        {
            switch (verb)
            {
                case HttpVerb.Get:
                    return await httpClient.GetAsync(requestUri);

                case HttpVerb.Post:
                    return await httpClient.PostAsync(requestUri, content);

                case HttpVerb.Put:
                    return await httpClient.PutAsync(requestUri, content);

                case HttpVerb.Delete:
                    return await httpClient.DeleteAsync(requestUri);

                default:
                    throw new ArgumentException("Verb not allowed.");
            }
        }

        private static async Task<Result<TResponse>> GenerateResultFromHttpResponseAsync<TResponse>(HttpResponseMessage httpResponse)
           where TResponse : class, new()
        {
            //TODO: rever isso aqui
            if (httpResponse.Content?.Headers?.ContentType?.MediaType == "text/html")
            {
                var resultHtml = new Result<TResponse> { Value = new TResponse() };
                return resultHtml;
            }

            IHttpResponseToResult deserializer = HttpResponseToResultFactory.GetDeserializer(httpResponse);
            Result<TResponse> result = await deserializer.DeserializeAsync<TResponse>(httpResponse);
            return result;
        }

        private static void UpdateResultStatusFromHttpResponse<TResponse>(Result<TResponse> result, HttpResponseMessage httpResponse)
            where TResponse : class
        {
            if (result.Message != Constant.Success)
            {
                result.Set((ResultCode)((int)httpResponse.StatusCode), result.Message, result.Validations);
                return;
            }

            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    result.Set(ResultCode.Ok, Constant.Success);
                    break;

                case HttpStatusCode.Created:
                    result.Set((ResultCode)((int)HttpStatusCode.Created), "Created");
                    break;

                case HttpStatusCode.RequestTimeout:
                    result.Set((ResultCode)((int)HttpStatusCode.RequestTimeout), "Request timeout");
                    break;

                case HttpStatusCode.GatewayTimeout:
                    result.Set((ResultCode)((int)HttpStatusCode.GatewayTimeout), "Gateway timeout");
                    break;

                case HttpStatusCode.Accepted:
                    result.Set((ResultCode)((int)HttpStatusCode.Accepted), "Accepted");
                    break;

                case HttpStatusCode.NotAcceptable:
                    result.Set((ResultCode)((int)HttpStatusCode.NotAcceptable), "Not Acceptable");
                    break;

                case HttpStatusCode.BadRequest:
                    if (!string.IsNullOrWhiteSpace(result.Message) && result.Message != Constant.Success)
                        result.Set((ResultCode)((int)HttpStatusCode.BadRequest), result.Message.Replace("Validation - ", ""));
                    else
                        result.Set((ResultCode)((int)HttpStatusCode.BadRequest), "Bad request");
                    break;

                case HttpStatusCode.Forbidden:
                    result.Set((ResultCode)((int)HttpStatusCode.Forbidden), "Forbidden");
                    break;

                case HttpStatusCode.InternalServerError:
                    result.Set((ResultCode)((int)HttpStatusCode.InternalServerError), "Internal Server Error");
                    break;

                case HttpStatusCode.NotFound:
                    result.Set((ResultCode)((int)HttpStatusCode.NotFound), "Not Found");
                    break;

                case HttpStatusCode.ServiceUnavailable:
                    result.Set((ResultCode)((int)HttpStatusCode.ServiceUnavailable), "Service Unavailable");
                    break;

                case HttpStatusCode.Unauthorized:
                    result.Set((ResultCode)((int)HttpStatusCode.Unauthorized), "Unauthorized");
                    break;

                case HttpStatusCode.MethodNotAllowed:
                    result.Set((ResultCode)((int)HttpStatusCode.MethodNotAllowed), "MethodNotAllowed in subsequent HTTP request.");
                    break;

                case (HttpStatusCode)422:
                    if (!string.IsNullOrWhiteSpace(result.Message) && result.Message != Constant.Success)
                        result.Set((ResultCode)422, result.Message.Replace("Validation - ", ""));
                    else
                        result.Set((ResultCode)422, null);
                    break;

                default:
                    if ((int)httpResponse.StatusCode > 400)
                        result.Set((ResultCode)((int)httpResponse.StatusCode), $"Error returned in HttpClient call: {httpResponse.StatusCode} - {httpResponse.ReasonPhrase}");
                    else
                        result.Set((ResultCode)((int)httpResponse.StatusCode), result.Message ?? Constant.Success);
                    break;
            }
        }

        /// <summary>
        /// Cria a Uri completa, adicionando os parametros a partir do request informado
        /// </summary>
        /// <param name="requestUri">URI para realização da chamada HTTP. A URL chamada no HTTP será composta pela URI Base + esta URI.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        private static async Task<string> CreateUriWithParamsFromRequestAsync(string requestUri, object request)
        {
            if (request == null)
                return requestUri;

            string queryString = await request.ToQueryStringAsync();

            if (string.IsNullOrWhiteSpace(queryString))
                return requestUri;

            if (!string.IsNullOrWhiteSpace(requestUri) && !requestUri.EndsWith("?"))
                requestUri += "?";

            return requestUri + queryString;
        }

        #endregion Privates
    }
}