using Myframework.Libraries.Application.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configurações de binders.
    /// </summary>
    public static class BindersConfigurations
    {
        /// <summary>
        /// Configura os binders para a cultura corrente. O maior ganho é quando o client envia para a API uma data ou número como string, garantindo que o binder respeite a cultura.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static MvcOptions ConfigureCurrentCultureModelBinders(this MvcOptions options, IConfiguration configuration)
        {
            options.ModelBinderProviders.Insert(0, new CurrentCultureDateTimeBinderProvider());
            options.ModelBinderProviders.Insert(0, new CurrentCultureDecimalBinderProvider());
            options.ModelBinderProviders.Insert(0, new CurrentCultureDoubleBinderProvider());
            options.ModelBinderProviders.Insert(0, new CurrentCultureFloatBinderProvider());

            return options;
        }
    }
}