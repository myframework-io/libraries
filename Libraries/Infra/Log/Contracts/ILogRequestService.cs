using Myframework.Libraries.Infra.Log.Models;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Log.Contracts
{
    /// <summary>
    /// Interface para log de requisição.
    /// </summary>
    public interface ILogRequestService
    {
        /// <summary>
        /// Loga a requisição.
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        Task LogRequestAsync(LogRequest log);
    }
}