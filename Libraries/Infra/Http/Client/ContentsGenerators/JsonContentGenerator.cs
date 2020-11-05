using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Myframework.Libraries.Infra.Http.Client.ContentsGenerators
{
    /// <summary>
    /// Gerador de conteúdo HTTP do tipo json.
    /// </summary>
    public class JsonContentGenerator : IHttpContentGenerator
    {
        private const string mediaType = "application/json";
        private readonly Encoding encoding;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        public JsonContentGenerator(Encoding encoding = null) => this.encoding = encoding == null ? Encoding.UTF8 : encoding;

        /// <summary>
        /// Transforma o objeto em conteúdo HTTP do tipo json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HttpContent GenerateContent(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, encoding, mediaType);
        }
    }
}