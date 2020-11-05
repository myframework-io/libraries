using Myframework.Libraries.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos utiliários para enumeradores.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Retorna todos os items de um enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetEnumItems<T>()
            where T : struct
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
                return null;

            return Enum.GetValues(enumType).Cast<T>().ToList();
        }

        /// <summary>
        /// Retorna o enum que possuir o atributo Description com o texto informado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="descriptionAttrText">Texto que está definido no aributo Description do enum.</param>
        /// <returns></returns>
        public static T? GetEnumByDescription<T>(string descriptionAttrText)
            where T : struct
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum || descriptionAttrText.IsNullOrWhiteSpace())
                return null;

            FieldInfo[] fields = enumType.GetFields();
            descriptionAttrText = descriptionAttrText.ToLower();

            T? fieldEnumField = null;

            foreach (FieldInfo field in fields)
            {
                DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute != null && attribute.Description.ToLower() == descriptionAttrText)
                    return (T)field.GetValue(null);

                if (attribute == null && field.Name.ToLower() == descriptionAttrText)
                    fieldEnumField = (T)field.GetValue(null);
            }

            return fieldEnumField;
        }
    }
}