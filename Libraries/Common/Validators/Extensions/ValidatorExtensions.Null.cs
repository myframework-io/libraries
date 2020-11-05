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
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="str">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Null(this string str, string errorMsg = null) => new ValidatorClassResult<string>(str).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result">.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Null(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="guid">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Null(this Guid? guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Null(this Guid guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Null(this ValidatorStructResult<Guid> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<int> Null(this int? value, string errorMsg = null) => new ValidatorStructResult<int>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> Null(this int value, string errorMsg = null) => new ValidatorStructResult<int>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> Null(this ValidatorStructResult<int> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<long> Null(this long? value, string errorMsg = null) => new ValidatorStructResult<long>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> Null(this long value, string errorMsg = null) => new ValidatorStructResult<long>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> Null(this ValidatorStructResult<long> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<short> Null(this short? value, string errorMsg = null) => new ValidatorStructResult<short>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> Null(this short value, string errorMsg = null) => new ValidatorStructResult<short>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> Null(this ValidatorStructResult<short> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> Null(this decimal? value, string errorMsg = null) => new ValidatorStructResult<decimal>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> Null(this decimal value, string errorMsg = null) => new ValidatorStructResult<decimal>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> Null(this ValidatorStructResult<decimal> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<double> Null(this double? value, string errorMsg = null) => new ValidatorStructResult<double>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> Null(this double value, string errorMsg = null) => new ValidatorStructResult<double>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> Null(this ValidatorStructResult<double> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<float> Null(this float? value, string errorMsg = null) => new ValidatorStructResult<float>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> Null(this float value, string errorMsg = null) => new ValidatorStructResult<float>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> Null(this ValidatorStructResult<float> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> Null(this byte? value, string errorMsg = null) => new ValidatorStructResult<byte>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> Null(this byte value, string errorMsg = null) => new ValidatorStructResult<byte>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> Null(this ValidatorStructResult<byte> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> Null(this DateTime? value, string errorMsg = null) => new ValidatorStructResult<DateTime>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> Null(this DateTime value, string errorMsg = null) => new ValidatorStructResult<DateTime>(value).Null(errorMsg);

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> Null(this ValidatorStructResult<DateTime> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="obj">Valor a ser testado.</param>
        /// <param name="errorMsg">Mensagem que será mostrada para esta validação.</param>
        /// <returns></returns>
        public static ValidatorClassResult<object> Null(this object obj, string errorMsg = null)
        {
            object trueObj = obj;

            if (obj == null)
                return new ValidatorClassResult<object>(obj).Null(errorMsg);

            Type objType = obj.GetType();

            if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(ValidatorClassResult<object>).GetGenericTypeDefinition())
                trueObj = objType.GetProperty(nameof(ValidatorClassResult<object>.OriginalValue)).GetValue(obj);

            return new ValidatorClassResult<object>(trueObj).Null(errorMsg);
        }

        /// <summary>
        /// Valida se o valor é nulo, caso contrário gera um resultado inválido.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<object> Null(this ValidatorClassResult<object> result, string errorMsg = null) => result.AddValidator(new NullValidator(result.OriginalValue, errorMsg));
    }
}