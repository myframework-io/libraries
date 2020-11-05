using Myframework.Libraries.Application.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configurações de globalização da API.
    /// </summary>
    // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/localization?view=aspnetcore-2.2
    public static class GlobalizationConfigurations
    {
        /// <summary>
        /// Adiciona suporte a globalização para a API.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="appSettingsGlobalizationSection">Seção do appsettings, onde estão as configurações de globalização.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlobalization(this IApplicationBuilder app, IConfiguration configuration, string appSettingsGlobalizationSection = "Globalization")
        {
            var globalizationOptions = new GlobalizationOptions();
            configuration.GetSection(appSettingsGlobalizationSection).Bind(globalizationOptions);

            var requestOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = GetDefaultRequestCulture(globalizationOptions.DefaultRequestCulture),
                SupportedCultures = GetSupportedCultures(globalizationOptions.SupportedCultures),
                SupportedUICultures = GetSupportedUICultures(globalizationOptions.SupportedUICultures),
            };

            if (!globalizationOptions.UseQueryStringRequestCultureProvider)
            {
                RequestCultureProvider requestProvider = requestOptions.RequestCultureProviders.OfType<QueryStringRequestCultureProvider>().FirstOrDefault();

                if (requestProvider != null)
                    requestOptions.RequestCultureProviders.Remove(requestProvider);
            }

            app.UseRequestLocalization(requestOptions);

            return app;
        }

        /// <summary>
        /// Configura resources para a API.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="resourceNamespace"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureResources(this IServiceCollection services, string resourceNamespace = "Resources") =>
            services.AddLocalization(options => options.ResourcesPath = resourceNamespace);


        #region Default Cultures

        private static RequestCulture GetDefaultRequestCulture(string defaultRequestCulture) =>
            string.IsNullOrWhiteSpace(defaultRequestCulture) ? new RequestCulture("en-US") : new RequestCulture(defaultRequestCulture);

        private static List<CultureInfo> GetSupportedCultures(List<string> supportedCultures)
        {
            if (supportedCultures == null || !supportedCultures.Any())
                return DefaultSupportedCultures;

            return supportedCultures.Select(it => new CultureInfo(it)).ToList();
        }

        private static List<CultureInfo> GetSupportedUICultures(List<string> supportedUICultures)
        {
            if (supportedUICultures == null || !supportedUICultures.Any())
                return DefaultSupportedUICultures;

            return supportedUICultures.Select(it => new CultureInfo(it)).ToList();
        }

        private static List<CultureInfo> DefaultSupportedCultures => new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr-BE"),
                    new CultureInfo("nl-BE"),
                    new CultureInfo("es-CO"),
                    new CultureInfo("es-CL"),
                    new CultureInfo("es-UY"),
                    new CultureInfo("es")
                };

        private static List<CultureInfo> DefaultSupportedUICultures => new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr-BE"),
                    new CultureInfo("nl-BE"),
                    new CultureInfo("es-CO"),
                    new CultureInfo("es-CL"),
                    new CultureInfo("es-UY"),
                    new CultureInfo("es")
                };

        #endregion Default Cultures

    }
}