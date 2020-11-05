using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para Json.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Remove dados sensíveis do json, trocando-os pela máscara informada.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propriedadesSensitive">Propriedades que devem ser trocadas pela máscara.</param>
        /// <param name="mask">Texto que será assumido no lugar das propriedades sensíveis.</param>
        /// <returns></returns>
        public static string RemoveSensitiveData(string json, List<string> propriedadesSensitive, string mask = "***")
        {
            bool validJson = CheckIfJsonIsValid(json);

            if (string.IsNullOrWhiteSpace(json) || json.StartsWith(mask) || !validJson)
                return json;

            dynamic dynObj = JsonConvert.DeserializeObject(json);

            var jObj = dynObj as JObject;

            if (jObj == null)
                return json;

            RemoveSensitiveDataRecursive(jObj.Children(), propriedadesSensitive, mask);

            return jObj.ToString();
        }

        /// <summary>
        /// Verifica se o json é válido.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool CheckIfJsonIsValid(string json)
        {
            json = json.Trim();

            if ((json.StartsWith("{") && json.EndsWith("}")) ||
                (json.StartsWith("[") && json.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(json);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void RemoveSensitiveDataRecursive(IEnumerable<JToken> children, List<string> propriedadesSensitive, string mask)
        {
            if (!children.Any())
                return;

            foreach (JToken token in children)
            {
                var prop = token as JProperty;

                if (prop == null)
                    continue;

                if (prop.Value != null && prop.Value.Type == JTokenType.Object)
                    RemoveSensitiveDataRecursive(prop.Value.Children(), propriedadesSensitive, mask);
                else
                {
                    if (propriedadesSensitive.Contains(prop.Name.ToLower()))
                        prop.Value = mask;
                }
            }
        }
    }
}