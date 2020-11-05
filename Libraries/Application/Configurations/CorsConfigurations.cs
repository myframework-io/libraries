using Microsoft.Extensions.DependencyInjection;

namespace Myframework.Libraries.Application.Configurations
{
    /*****************************************************************************************************************************
     * Problemas conhecidos:
     * - CORS bloqueando requisição, mesmo com tudo configurado para "allow": 
     *   https://stackoverflow.com/questions/19162825/web-api-put-request-generates-an-http-405-method-not-allowed-error
     *****************************************************************************************************************************/

    /// <summary>
    /// Extensões do IServiceCollection para configurações de CORS (Cross-origin resource sharing).
    /// https://docs.microsoft.com/en-US/aspnet/core/security/cors?view=aspnetcore-2.1
    /// </summary>
    public static class CorsConfigurations
    {
        /// <summary>
        /// Configura o CORS para permitir qualquer acesso.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="corsPolicyName"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureCorsForAllowAny(this IServiceCollection services, string corsPolicyName)
        {
            return
                services.AddCors(options =>
                {
                    options.AddPolicy(corsPolicyName,
                      builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

                    /*options.AddPolicy(corsPolicyName,
                      builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());*/
                });
        }
    }
}