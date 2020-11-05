using System.Threading.Tasks;

namespace Myframework.Libraries.Application.MVC
{
    /// <summary>
    /// Interface para mecanismo de renderização de view como string.
    /// </summary>
    public interface IViewRenderService
    {
        /// <summary>
        /// Renderiza uma view como string.
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}