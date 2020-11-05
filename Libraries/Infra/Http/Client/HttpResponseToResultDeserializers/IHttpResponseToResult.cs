using Myframework.Libraries.Common.Results;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Http.Client.HttpResponseToResultDeserializers
{
    /// <summary>
    /// Interface que define o responsável por deserializar um retorno HTTP em HttpResult.
    /// </summary>
    public interface IHttpResponseToResult
    {
        /// <summary>
        /// Deserializa um retorno HTTP em HttpResult.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        Task<Result<TResponse>> DeserializeAsync<TResponse>(HttpResponseMessage httpResponse)
             where TResponse : class, new();
    }
}