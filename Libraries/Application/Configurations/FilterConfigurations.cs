using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configurações de filtros.
    /// </summary>
    public static class FilterConfigurations
    {
        /// <summary>
        /// Desabilita o retorno automático do asp.net para model state invalido. O model state será tratado por um filtro personalizado (ValidateBaseRequestMessageFilter)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection SuppressModelStateInvalidFilter(this IServiceCollection services) =>
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
    }
}