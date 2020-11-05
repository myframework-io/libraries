using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> PositiveNumber(this long? number, string errorMsg = null)
            => new ValidatorStructResult<long>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> PositiveNumber(this long number, string errorMsg = null)
            => new ValidatorStructResult<long>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> PositiveNumber(this ValidatorStructResult<long> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> PositiveNumber(this int? number, string errorMsg = null)
            => new ValidatorStructResult<int>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> PositiveNumber(this int number, string errorMsg = null)
            => new ValidatorStructResult<int>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> PositiveNumber(this ValidatorStructResult<int> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> PositiveNumber(this short? number, string errorMsg = null)
            => new ValidatorStructResult<short>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> PositiveNumber(this short number, string errorMsg = null)
            => new ValidatorStructResult<short>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> PositiveNumber(this ValidatorStructResult<short> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> PositiveNumber(this byte? number, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> PositiveNumber(this byte number, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> PositiveNumber(this ValidatorStructResult<byte> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> PositiveNumber(this decimal? number, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> PositiveNumber(this decimal number, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> PositiveNumber(this ValidatorStructResult<decimal> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> PositiveNumber(this float? number, string errorMsg = null)
            => new ValidatorStructResult<float>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> PositiveNumber(this float number, string errorMsg = null)
            => new ValidatorStructResult<float>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> PositiveNumber(this ValidatorStructResult<float> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> PositiveNumber(this double? number, string errorMsg = null)
            => new ValidatorStructResult<double>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="number"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> PositiveNumber(this double number, string errorMsg = null)
            => new ValidatorStructResult<double>(number).PositiveNumber(errorMsg);

        /// <summary>
        /// Valida se o número é positivo.
        /// </summary>
        /// <param name="result"></param>        
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> PositiveNumber(this ValidatorStructResult<double> result, string errorMsg = null)
            => result.AddValidator(new PositiveNumberValidator(result.OriginalValue, errorMsg));
    }
}