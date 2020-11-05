using Autofac;
using Myframework.Libraries.Application.ApplicationInsights;
using Myframework.Libraries.Application.BackgroundTasks;
using Myframework.Libraries.Domain.Repositories;
using Myframework.Libraries.Infra.CQRS.Queries;
using Myframework.Libraries.Infra.Http;
using Microsoft.ApplicationInsights.Extensibility;
using System.Reflection;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Módulo padrão de injeção de dependência para a camada Application.
    /// Realiza scan de queries (IQueries) e repositórios (IRepository) para criar as injeções de dependências.
    /// </summary>
    public class ApplicationModuleDI : Autofac.Module
    {
        private readonly Assembly queriesAssembly;
        private readonly Assembly repositoriesAssembly;
        private readonly Assembly httpServicesAssembly;
        private readonly Assembly backgroundTasksAssembly;

        /// <summary>
        /// Construtor padrão que exige que sejam informados os assemblies de query, repositório e communication services para escaneamento.
        /// </summary>
        /// <param name="queriesAssembly">Assembly no qual estão as queries.</param>
        /// <param name="repositoriesAssembly">Assembly no qual estão os repositórios.</param>
        /// <param name="httpServicesAssembly">Assembly no qual estão os HTTP services. Opcional.</param>
        /// <param name="backgroundTasksAssembly">Assembly no qual estão as background taks.</param>
        public ApplicationModuleDI(Assembly queriesAssembly, Assembly repositoriesAssembly, Assembly httpServicesAssembly = null, Assembly backgroundTasksAssembly = null)
        {
            this.queriesAssembly = queriesAssembly;
            this.repositoriesAssembly = repositoriesAssembly;
            this.httpServicesAssembly = httpServicesAssembly;
            this.backgroundTasksAssembly = backgroundTasksAssembly;
        }

        /// <summary>
        /// Adiciona registros ao container de injeção.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(queriesAssembly)
                .As(typeof(IQueries))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(repositoriesAssembly)
                .AsClosedTypesOf(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            if (httpServicesAssembly != null)
            {
                builder.RegisterAssemblyTypes(httpServicesAssembly)
                  .As(typeof(IHttpService))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
            }

            if (backgroundTasksAssembly != null)
            {
                builder.RegisterAssemblyTypes(backgroundTasksAssembly)
                  .As(typeof(IBackgroundTask))
                  .AsImplementedInterfaces()
                  .SingleInstance();
            }

            builder.RegisterType<HttpContextRequestTelemetryInitializer>().As<ITelemetryInitializer>().SingleInstance();
        }
    }
}