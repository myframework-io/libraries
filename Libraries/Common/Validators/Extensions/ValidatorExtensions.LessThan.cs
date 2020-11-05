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
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThan(this long? number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThan(this long number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThan(this ValidatorStructResult<long> result, long numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThan(this int? number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThan(this int number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThan(this ValidatorStructResult<int> result, int numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThan(this short? number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThan(this short number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThan(this ValidatorStructResult<short> result, short numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThan(this byte? number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThan(this byte number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThan(this ValidatorStructResult<byte> result, byte numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThan(this decimal? number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThan(this decimal number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThan(this ValidatorStructResult<decimal> result, decimal numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThan(this float? number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThan(this float number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThan(this ValidatorStructResult<float> result, float numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThan(this double? number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThan(this double number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).LessThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThan(this ValidatorStructResult<double> result, double numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThan(this DateTime? data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).LessThan(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThan(this DateTime data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).LessThan(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThan(this ValidatorStructResult<DateTime> result, DateTime dataCompare, string errorMsg = null)
            => result.AddValidator(new LessThanValidator(result.OriginalValue, dataCompare, errorMsg));
    }
}