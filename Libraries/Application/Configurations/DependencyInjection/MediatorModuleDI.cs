using Autofac;
using Myframework.Libraries.Infra.CQRS.Mediators;
using MediatR;
using System.Reflection;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Módulo padrão de injeção de dependência para o Mediator.
    /// Realiza scan de commands e handlers para criar as injeções de dependências.
    /// </summary>
    public class MediatorModuleDI : Autofac.Module
    {
        private readonly Assembly commandsAndEventsHandlersAssemblies;

        /// <summary>
        /// Construtor padrão que exige que sejam informados os assemblies handlers dos comandos e eventos para escaneamento.
        /// </summary>
        /// <param name="commandsAssemble">Assembly no qual estão os commandos e handlers.</param>
        public MediatorModuleDI(Assembly commandsAndEventsHandlersAssemblies) => this.commandsAndEventsHandlersAssemblies = commandsAndEventsHandlersAssemblies;

        /// <summary>
        /// Adiciona registros ao container de injeção.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<InMemoryMediatorHandler>()
                .As<IMediatorHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(commandsAndEventsHandlersAssemblies)
               .AsClosedTypesOf(typeof(IRequestHandler<,>))
               .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                return t => { return componentContext.TryResolve(t, out object o) ? o : null; };
            });
        }
    }
}