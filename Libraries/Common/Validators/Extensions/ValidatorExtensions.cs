using Myframework.Libraries.Common.Validators.Types;
using System;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida se a função informada é verdadeira.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="funcMust"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<object> Must(this object obj, Func<bool> funcMust, string errorMsg)
            => new ValidatorClassResult<object>(obj).Must(funcMust, errorMsg);

        /// <summary>
        /// Valida se a função informada é verdadeira.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="funcMust"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<T> Must<T>(this T obj, Func<bool> funcMust, string errorMsg) where T : class
            => new ValidatorClassResult<T>(obj).Must(funcMust, errorMsg);

        /// <summary>
        /// Valida se a função informada é verdadeira.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="funcMust"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<T> Must<T>(this ValidatorClassResult<T> result, Func<bool> funcMust, string errorMsg) where T : class
            => result.AddValidator(new MustValidator(funcMust, errorMsg));

        /// <summary>
        /// Valida se a função informada é verdadeira.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="funcMust"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<T> Must<T>(this ValidatorStructResult<T> result, Func<bool> funcMust, string errorMsg) where T : struct
            => result.AddValidator(new MustValidator(funcMust, errorMsg));
    }
}