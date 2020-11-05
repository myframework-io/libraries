using Myframework.Libraries.Common.Results;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Security
{
    /// <summary>
    /// Classe para gerar token de acesso do tipo client a partir do servidor de autenticação.
    /// Utilize essa classe como Singleton na injeção de dependência.
    /// </summary>
    public class ClientTokenManager : IClientTokenManager
    {
        private readonly string lockControl = "";
        private readonly SecurityOptions options;
        private DiscoveryDocumentResponse disco;
        private TokenResponse lastTokenResponse;
        private DateTime? TokenExpiresAt = null;

        public ClientTokenManager(IOptions<SecurityOptions> options)
        {
            this.options = options.Value;

            if (options.Value == null)
                throw new Exception($"{nameof(ClientTokenManager)}: options null.");
        }

        public ClientTokenManager(IOptions<SecurityOptions> options, string authorityUrl)
        {
            this.options = options.Value;

            if (options.Value == null)
                throw new Exception($"{nameof(ClientTokenManager)}: options null.");

            this.options.AuthorityUrl = authorityUrl ?? this.options.AuthorityUrl;
        }

        /// <summary>
        /// Obtém o token de acesso para o client. Esse método também realiza o refresh do token caso esteja expirado ou esteja para expirar.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<string>> GetAccessTokenAsync()
        {
            var result = new Result<string>();

            if (disco == null || disco.IsError)
            {
                var client = new HttpClient();
                disco = await client.GetDiscoveryDocumentAsync(options.AuthorityUrl);
            }

            if (disco.IsError)
                return result.Set(ResultCode.GenericError, $"Authentication discovery fail. Error: {disco.Error}");

            if (lastTokenResponse == null)
            {
                Result resultReset = await ResetAccessTokenAsync();

                if (!resultReset.Valid)
                    return result.SetFromAnother(resultReset);
            }
            else
            {
                double secondsLeftToRefresh = lastTokenResponse.ExpiresIn * 0.4;
                DateTime refreshDate = TokenExpiresAt.Value.AddSeconds(secondsLeftToRefresh * -1);

                if (DateTime.UtcNow > TokenExpiresAt.Value || DateTime.UtcNow > refreshDate)
                {
                    Result resultReset = await ResetAccessTokenAsync();

                    if (!resultReset.Valid)
                    {
                        Result resultRefresh = await ResetAccessTokenAsync();

                        if (!resultRefresh.Valid)
                            return result.SetFromAnother(resultRefresh);
                    }
                }
            }

            result.Value = lastTokenResponse?.AccessToken;

            return result;
        }

        /// <summary>
        /// Reseta o token atual e força uma nova autenticação.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<string>> ResetAccessTokenAsync()
        {
            var result = new Result<string>();

            if (disco == null || disco.IsError)
            {
                var client = new HttpClient();
                disco = await client.GetDiscoveryDocumentAsync(options.AuthorityUrl);
            }

            if (disco.IsError)
                return result.Set(ResultCode.GenericError, $"Authentication discovery fail. Error: {disco.Error}");

            lock (lockControl)
            {
                lastTokenResponse = null;
                TokenExpiresAt = null;
            }

            Result<TokenResponse> resultGenerate = await GenerateClientCredentialsTokenAsync();

            if (!resultGenerate.Valid)
            {
                lock (lockControl)
                {
                    lastTokenResponse = null;
                    TokenExpiresAt = null;
                }

                return result.SetFromAnother(resultGenerate);
            }

            result.Value = resultGenerate.Value.AccessToken;

            return result;
        }

        private async Task<Result<TokenResponse>> GenerateClientCredentialsTokenAsync()
        {
            var result = new Result<TokenResponse>();
            var client = new HttpClient();

            TokenResponse response = await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = options.ClientId,
                    ClientSecret = options.ClientSecret,
                    Scope = options.ClientScope
                });

            if (response.IsError)
                return result.Set(ResultCode.GenericError, response.Error);

            lock (lockControl)
            {
                lastTokenResponse = response;
                TokenExpiresAt = DateTime.UtcNow.AddSeconds(response.ExpiresIn);
            }

            result.Value = response;

            return result;
        }
    }
}