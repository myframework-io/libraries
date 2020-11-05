using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.Http.Exensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Http
{
    [Obsolete("Usar novo modelo de HttpClient. Dúvidas, entre em contato com a equipe de arquitetura.")]
    public abstract class BaseHttpService : IHttpService
    {
        private readonly BaseHttpServiceOptions options;

        public BaseHttpService(BaseHttpServiceOptions options) =>
            this.options = options ?? throw new ArgumentException($"Options missing in {nameof(BaseHttpService)}.");

        protected async Task<Result<TResponse>> GetAsync<TResponse>(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.BaseUrl),
                Timeout = options.Timeout
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RemoveBearerFromToken(token));

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                }
            }

            return await httpClient.GetResultAsync<TResponse>(
                requestUri: route,
                queryStringObject: request,
                headers: new Dictionary<string, string> { { Constant.Protocol, protocol.ToString() } });
        }

        protected async Task<Result> PostAsync(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null) =>
            await PostAsync<object>(token, route, protocol, request, headers);

        protected async Task<Result<TResponse>> PostAsync<TResponse>(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.BaseUrl),
                Timeout = options.Timeout
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RemoveBearerFromToken(token));

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                }
            }

            return await httpClient.PostJsonResultAsync<TResponse>(
                requestUri: route,
                bodyObject: request,
                headers: new Dictionary<string, string> { { Constant.Protocol, protocol.ToString() } });
        }

        protected async Task<Result> PutAsync(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null) =>
            await PutAsync<object>(token, route, protocol, request, headers);

        protected async Task<Result<TResponse>> PutAsync<TResponse>(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.BaseUrl),
                Timeout = options.Timeout
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RemoveBearerFromToken(token));
            httpClient.DefaultRequestHeaders.Add(Constant.Protocol, protocol.ToString());

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                }
            }

            return await httpClient.PutJsonResultAsync<TResponse>(requestUri: route, bodyObject: request);
        }

        protected async Task<Result> DeleteAsync(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null) =>
            await DeleteAsync<object>(token, route, protocol, request, headers);

        protected async Task<Result<TResponse>> DeleteAsync<TResponse>(string token, string route, Guid protocol, object request, Dictionary<string, string> headers = null)
            where TResponse : class, new()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.BaseUrl),
                Timeout = options.Timeout
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", RemoveBearerFromToken(token));

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                }
            }

            return await httpClient.DeleteResultAsync<TResponse>(
                  requestUri: route,
                  queryStringObject: request,
                  headers: new Dictionary<string, string> { { Constant.Protocol, protocol.ToString() } });
        }

        protected async Task<Result<T>> PostJsonLegacyApisAsync<T>(string route, object request, string baseUrl = null, string authToken = null)
           where T : class
        {
            var result = new Result<T>();
            baseUrl = baseUrl ?? options.BaseUrl;

            try
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
                string jsonRequest = JsonConvert.SerializeObject(request);

                if (!string.IsNullOrWhiteSpace(authToken))
                    httpClient.DefaultRequestHeaders.Add(Constant.Authorization, authToken);

                HttpResponseMessage response = await httpClient.PostAsync(route, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    result.Value = JsonConvert.DeserializeObject<T>(jsonResponse);

                    return result;
                }

                return result.Set((ResultCode)(int)response.StatusCode, $"API returns HttpStatus {(int)response.StatusCode}");
            }
            catch (Exception exc)
            {
                return result.SetBusinessMessage($"Error calling API: {exc.ToString()}");
            }
        }

        protected string RemoveBearerFromToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return token;

            if (token.Trim().ToLower().StartsWith("bearer"))
                token = token.TrimStart().Substring(6).Trim();

            return token;
        }
    }
}