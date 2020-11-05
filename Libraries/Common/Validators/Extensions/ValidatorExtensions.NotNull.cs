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
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> NotNull(this string str, string errorMsg = null) => new ValidatorClassResult<string>(str).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> NotNull(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> NotNull(this int? value, string errorMsg = null) => new ValidatorStructResult<int>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> NotNull(this int value, string errorMsg = null) => new ValidatorStructResult<int>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> NotNull(this ValidatorStructResult<int> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> NotNull(this long? value, string errorMsg = null) => new ValidatorStructResult<long>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> NotNull(this long value, string errorMsg = null) => new ValidatorStructResult<long>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> NotNull(this ValidatorStructResult<long> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> NotNull(this short? value, string errorMsg = null) => new ValidatorStructResult<short>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> NotNull(this short value, string errorMsg = null) => new ValidatorStructResult<short>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> NotNull(this ValidatorStructResult<short> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> NotNull(this decimal? value, string errorMsg = null) => new ValidatorStructResult<decimal>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> NotNull(this decimal value, string errorMsg = null) => new ValidatorStructResult<decimal>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> NotNull(this ValidatorStructResult<decimal> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> NotNull(this double? value, string errorMsg = null) => new ValidatorStructResult<double>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> NotNull(this double value, string errorMsg = null) => new ValidatorStructResult<double>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> NotNull(this ValidatorStructResult<double> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> NotNull(this float? value, string errorMsg = null) => new ValidatorStructResult<float>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> NotNull(this float value, string errorMsg = null) => new ValidatorStructResult<float>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> NotNull(this ValidatorStructResult<float> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> NotNull(this byte? value, string errorMsg = null) => new ValidatorStructResult<byte>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> NotNull(this byte value, string errorMsg = null) => new ValidatorStructResult<byte>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> NotNull(this ValidatorStructResult<byte> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotNull(this Guid? guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotNull(this Guid guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotNull(this ValidatorStructResult<Guid> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> NotNull(this DateTime? value, string errorMsg = null) => new ValidatorStructResult<DateTime>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> NotNull(this DateTime value, string errorMsg = null) => new ValidatorStructResult<DateTime>(value).NotNull(errorMsg);

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> NotNull(this ValidatorStructResult<DateTime> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<object> NotNull(this object obj, string errorMsg = null)
        {
            object trueObj = obj;

            if (obj == null)
                return new ValidatorClassResult<object>(obj).NotNull(errorMsg);

            Type objType = obj.GetType();

            if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(ValidatorClassResult<object>).GetGenericTypeDefinition())
                trueObj = objType.GetProperty(nameof(ValidatorClassResult<object>.OriginalValue)).GetValue(obj);

            return new ValidatorClassResult<object>(trueObj).NotNull(errorMsg);
        }

        /// <summary>
        /// Valida se o valor não é nulo.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<object> NotNull(this ValidatorClassResult<object> result, string errorMsg = null) => result.AddValidator(new NotNullValidator(result.OriginalValue, errorMsg));
    }
}