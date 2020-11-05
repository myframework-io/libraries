using Myframework.Libraries.Common.Results;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Http.Client.HttpResponseToResultDeserializers
{
    /// <summary>
    /// Deserializador responsável por deserializar um retorno HTTP em Result.
    /// </summary>
    public class HttpResponseToResultJsonDeserializer : IHttpResponseToResult
    {
        /// <summary>
        /// Deserializa um retorno HTTP em HttpResult.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public async Task<Result<TResponse>> DeserializeAsync<TResponse>(HttpResponseMessage httpResponse)
              where TResponse : class, new()
        {
            Result<TResponse> result;
            string responseBody = null;

            if (httpResponse?.Content != null)
                responseBody = await httpResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseBody))
            {
                result = new Result<TResponse>();
                return result;
            }

            var jsonSettings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error };
            //jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" });
            //jsonSettings.Converters.Add(new JsonDecimalCurrentCultureConverter());

            try
            {
                try
                {
                    //1) Tentar deserializar esperando q todos os campos estejam preenchidos
                    result = JsonConvert.DeserializeObject<Result<TResponse>>(responseBody, jsonSettings);
                }
                catch (Exception)
                {
                    //2) Tentar deserializar o json para o retorno do result, esse caso geralmente é chamando um serviço externo
                    result = new Result<TResponse>
                    {
                        Value = JsonConvert.DeserializeObject<TResponse>(responseBody, jsonSettings)
                    };
                }

                return result;
            }
            catch (Exception)
            {
                try
                {
                    //3) Se não conseguiu deserializar, tentar sem exigir q os campos estejam todos preenchidos
                    jsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    result = JsonConvert.DeserializeObject<Result<TResponse>>(responseBody, jsonSettings);

                    if (result == null)
                        result = new Result<TResponse>();

                    if (result.Value == null)
                        result.Value = JsonConvert.DeserializeObject<TResponse>(responseBody, jsonSettings);

                    return result;

                }
                catch (Exception)
                {
                    result = new Result<TResponse>();
                    result.SetBusinessMessage("Could not deserialize HTTP response.");
                    result.AddValidation("Json", responseBody);
                    return result;
                }
            }
        }
    }
}