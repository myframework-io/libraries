using Myframework.Libraries.Common.Results;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Security
{
    /// <summary>
    /// Classe para gerar token de acesso do tipo client a partir do servidor de autenticação.
    /// Utilize essa classe como Singleton na injeção de dependência.
    /// </summary>
    public interface IClientTokenManager
    {
        /// <summary>
        /// Obtém o token de acesso para o client. Esse método também realiza o refresh do token caso esteja expirado ou esteja para expirar.
        /// </summary>
        /// <returns></returns>
        Task<Result<string>> GetAccessTokenAsync();

        /// <summary>
        /// Reseta o token atual e força uma nova autenticação.
        /// </summary>
        /// <returns></returns>
        Task<Result<string>> ResetAccessTokenAsync();
    }
}