using System;
using System.ComponentModel;
using System.Linq;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Métodos de extensão para Enum.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Checa se um enum é valido, dentro da lista deste tipo de enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static bool IsDefined(this Enum enumType)
        {
            Type type = enumType.GetType();
            return Enum.IsDefined(type, enumType);
        }

        /// <summary>
        /// Obtém o texto do atributo Description que decora o enum.
        /// </summary>
        /// <param name="enumType"></param>
        public static string GetDescription(this Enum enumType)
        {
            DescriptionAttribute attr = enumType.GetAttribute<DescriptionAttribute>();
            return attr == null ? enumType.ToString() : attr.Description;
        }

        /// <summary>
        /// Retorna o atributo de um item de enum.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum enumType)
            where T : Attribute
        {
            var attribute = enumType
                .GetType()
                .GetField(enumType.ToString())
                .GetCustomAttributes(typeof(T), false)
                .FirstOrDefault() as T;

            return attribute;
        }
    }
}