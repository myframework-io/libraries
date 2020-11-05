using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configurações de monitoramento.
    /// https://docs.microsoft.com/pt-br/azure/azure-monitor/app/app-insights-overview
    /// </summary>
    public static class MonitoringConfigurations
    {
        /// <summary>
        /// Adiciona monitoramento via application insights.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureMonitoringByApplicationInsights(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection instrumentationKey = configuration.GetSection("ApplicationInsights:InstrumentationKey");
            string key = instrumentationKey?.Value;

            if (!string.IsNullOrWhiteSpace(key))
                services.AddApplicationInsightsTelemetry(key);

            return services;
        }
    }
}