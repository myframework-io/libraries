using System;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para Type.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Verifica se o tipo é uma subclasse de um genérico.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public static bool IsSubclassOfRawGeneric(this Type type, Type baseType)
        {
            while (type != null && type != typeof(object))
            {
                Type cur = type.IsGenericType ? type.GetGenericTypeDefinition() : type;

                if (baseType == cur)
                    return true;

                type = type.BaseType;
            }

            return false;
        }
    }
}