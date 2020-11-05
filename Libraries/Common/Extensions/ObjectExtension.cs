using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para objetos.
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Retorna uma QueryString baseada nas propriedades do objeto informado.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToQueryString(this object obj) => ToQueryStringAsync(obj).GetAwaiter().GetResult();

        /// <summary>
        /// Retorna uma QueryString baseada nas propriedades do objeto informado.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<string> ToQueryStringAsync(this object obj)
        {
            if (obj == null)
                return null;

            IDictionary<string, string> keyValueContent = obj.ToDictionary();

            if (keyValueContent == null)
                return null;

            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
            return await formUrlEncodedContent.ReadAsStringAsync();
        }

        /// <summary>
        /// Transforma o objeto em um dicionário com as propriedades (como chave) e seus valores.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this object obj)
        {
            if (obj == null)
                return null;

            var token = obj as JToken;

            if (token == null)
                return ToDictionary(JObject.FromObject(obj));

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (JToken child in token.Children().ToList())
                {
                    IDictionary<string, string> childContent = child.ToDictionary();

                    if (childContent != null)
                        contentData = contentData.Concat(childContent).ToDictionary(k => k.Key, v => v.Value);
                }

                return contentData;
            }

            var jValue = token as JValue;

            if (jValue?.Value == null)
                return null;

            string value =
                jValue?.Type == JTokenType.Date
                    ? jValue?.ToString("o", CultureInfo.InvariantCulture)
                    : jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }

        /// <summary>Checa se o objeto é nulo.</summary>
        public static bool IsNull(this object obj) => obj == null;

        /// <summary>Checa se o objeto não é nulo.</summary>
        public static bool IsNotNull(this object obj) => obj != null;
    }
}