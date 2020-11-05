using Microsoft.AspNetCore.Hosting;

namespace Myframework.Libraries.Application.Extensions
{
    /// <summary>
    /// Extensões para o IHostingEnvironment.
    /// </summary>
    public static class IHostingEnvironmentExtensions
    {
        /// <summary>
        /// Verifica se a variável de ambiente atual é "Local".
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <returns></returns>
        public static bool IsLocal(this IHostingEnvironment hostingEnvironment) =>
            hostingEnvironment.IsEnvironment("Local");

        /// <summary>
        /// Verifica se a variável de ambiente atual é "Test".
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <returns></returns>
        public static bool IsTest(this IHostingEnvironment hostingEnvironment) =>
            hostingEnvironment.IsEnvironment("Test");
    }
}