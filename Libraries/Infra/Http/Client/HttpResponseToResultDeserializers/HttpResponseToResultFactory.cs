using System.Net.Http;

namespace Myframework.Libraries.Infra.Http.Client.HttpResponseToResultDeserializers
{
    /// <summary>
    /// Fábrica responsável por selecionar o deserializador correspondente ao header MediaType.
    /// </summary>
    public static class HttpResponseToResultFactory
    {
        /// <summary>
        /// Obtém o deserializador correspondente ao header MediaType.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IHttpResponseToResult GetDeserializer(HttpResponseMessage response)
        {
            switch (response?.Content?.Headers?.ContentType?.MediaType)
            {
                case "application/json":
                default:
                    return new HttpResponseToResultJsonDeserializer();
            }
        }
    }
}