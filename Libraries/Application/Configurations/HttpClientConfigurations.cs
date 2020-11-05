using Myframework.Libraries.Infra.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões pra configurar HttpServices.
    /// https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.1
    /// </summary>
    public static class HttpClientConfigurations
    {
        /// <summary>
        /// Adiciona um novo HttpService com: timeout, wait/retry e circuitbreak, as configurações de cada parte devem estar no appsettings e serão vinculadas ao BaseHttpServiceOptions.
        /// </summary>
        /// <typeparam name="THttpServiceInterface"></typeparam>
        /// <typeparam name="THttpService"></typeparam>
        /// <param name="services"></param>
        /// <param name="baseHttpServiceOptions"></param>
        /// <returns></returns>
        public static IHttpClientBuilder ConfigureDefaultHttpService<THttpServiceInterface, THttpService>(this IServiceCollection services, BaseHttpServiceOptions baseHttpServiceOptions)
            where THttpServiceInterface : class
            where THttpService : class, THttpServiceInterface
        {
            return services
                .AddHttpClient<THttpServiceInterface, THttpService>(client => client.BaseAddress = new Uri(baseHttpServiceOptions.BaseUrl))
                .AddPolicyHandler(it => Policy.TimeoutAsync<HttpResponseMessage>(baseHttpServiceOptions.Timeout))
                .AddTransientHttpErrorPolicy(it => it.WaitAndRetryAsync(baseHttpServiceOptions.Retries, _ => baseHttpServiceOptions.RetryInterval))
                .AddTransientHttpErrorPolicy(it => it.CircuitBreakerAsync(baseHttpServiceOptions.MaxOfExceptionsToCircuitBreak, baseHttpServiceOptions.IntervalCircuitBreak));
        }
    }
}