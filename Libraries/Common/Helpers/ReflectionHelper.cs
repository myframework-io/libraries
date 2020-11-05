using System;
using System.ComponentModel;
using System.Reflection;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para relection.
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Retorna o text do atributo Description para um tipo.
        /// </summary>
        /// <returns></returns>
        public static string GetDescription<T>() where T : class => typeof(T).GetCustomAttribute<DescriptionAttribute>()?.Description;

        /// <summary>
        /// Retorna o text do atributo Description de uma propriedade específica.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetDescription<T>(string propertyName) where T : class => GetAttribute<T, DescriptionAttribute>(propertyName)?.Description;

        /// <summary>
        /// Retorna o atributo Description de uma propriedade específica.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static DescriptionAttribute GetDescriptionAttribute<T>(string propertyName) where T : class => GetAttribute<T, DescriptionAttribute>(propertyName);

        /// <summary>
        /// Verifica se um tipo possui um atributo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasAttribute<T, TAttribute>()
            where T : class
            where TAttribute : Attribute => typeof(T).GetCustomAttribute<TAttribute>() != null;

        /// <summary>
        /// Verifica se um tipo possui um atributo na propriedade específica.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasAttribute<T, TAttribute>(string propertyName)
            where T : class
            where TAttribute : Attribute => GetAttribute<T, TAttribute>(propertyName) != null;

        /// <summary>
        /// Retorna o atributo de uma propriedade.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<T, TAttribute>(string propertyName)
            where T : class
            where TAttribute : Attribute
        {
            PropertyInfo info = typeof(T).GetProperty(propertyName);
            return info == null ? null : info.GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Retorna as propriedades do tipo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties<T>()
            where T : class => typeof(T).GetProperties();

        /// <summary>
        /// Atualiza a propriedade de um objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="newValue"></param>
        public static void SetPropertyValue<T>(T obj, string propertyName, object newValue)
            where T : class => typeof(T).GetProperty(propertyName).SetValue(obj, newValue);

        /// <summary>
        /// Retorna o valor da propriedade de um objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        public static object GetPropertyValue<T>(T obj, string propertyName)
            where T : class => typeof(T).GetProperty(propertyName).GetValue(obj);

        /// <summary>
        /// Atualiza um campo não público com o novo valor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fieldName"></param>
        /// <param name="newValue"></param>
        public static void SetNonPublicField<T>(T obj, string fieldName, object newValue)
            where T : class => typeof(T).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(obj, newValue);

        /// <summary>
        /// Retorna o valor de um campo não público com.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fieldName"></param>
        public static object GetNonPublicField<T>(T obj, string fieldName)
            where T : class => typeof(T).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);
    }
}