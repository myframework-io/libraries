using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Http.Handlers
{
    /// <summary>
    /// Delegating handle para adicionar à requisição de um HttpClient o acess token presente no HttpContext.    
    /// </summary>
    /// <remarks>
    /// Deve ser incluído na injeção de dependencia, como por exemplo: <strong><i>services.AddTransient&lt;BearerTokenHandler&gt;();</i></strong>.
    /// Usado, geralmente, em aplicações ASP.NET MVC.
    /// </remarks>
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BearerTokenHandler(IHttpContextAccessor httpContextAccessor) =>
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string accessToken = await httpContextAccessor.HttpContext?.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            if (!string.IsNullOrWhiteSpace(accessToken))
                request.SetBearerToken(accessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}