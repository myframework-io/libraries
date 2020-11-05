using Autofac;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configuração de injeção de dependências.
    /// </summary>
    public static class DependencyInjectionConfigurations
    {
        /// <summary>
        /// Configura a injeção de dependêcia com módulos os módulos (Autofac) default da arquitetura.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="commandsAssembly">Assembly no qual estão os comandos.</param>
        /// <param name="queriesAssembly">Assembly no qual estão as queries.</param>
        /// <param name="repositoryAssembly">Assembly no qual estão os repositórios.</param>
        /// <param name="httpServicesAssembly">Assembly no qual estão os HTTP services.</param>
        /// <param name="backgroundTasksAssembly">Assembly no qual estão as background taks.</param>
        /// <param name="aditionalModules">Módulos adicionais, caso seja necessário.</param>
        /// <returns></returns>
        public static void ConfigureAutofacDIWithDefaultModules(this ContainerBuilder container,
            System.Reflection.Assembly commandsAssembly,
            System.Reflection.Assembly queriesAssembly,
            System.Reflection.Assembly repositoryAssembly,
            System.Reflection.Assembly httpServicesAssembly = null,
            System.Reflection.Assembly backgroundTasksAssembly = null,
            params Module[] aditionalModules)
        {
            container.RegisterModule(new MediatorModuleDI(commandsAssembly));
            container.RegisterModule(new ApplicationModuleDI(queriesAssembly, repositoryAssembly, httpServicesAssembly, backgroundTasksAssembly));

            if (aditionalModules != null)
            {
                foreach (Module module in aditionalModules)
                {
                    container.RegisterModule(module);
                }
            }
        }
    }
}