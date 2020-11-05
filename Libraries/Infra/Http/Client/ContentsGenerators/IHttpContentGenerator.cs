using System.Net.Http;

namespace Myframework.Libraries.Infra.Http.Client.ContentsGenerators
{
    /// <summary>
    /// Interface usada para gerador de conteúdo HTTP (json, xml, etc).
    /// </summary>
    public interface IHttpContentGenerator
    {
        /// <summary>
        /// Transforma o objeto em conteúdo HTTP.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        HttpContent GenerateContent(object obj);
    }
}