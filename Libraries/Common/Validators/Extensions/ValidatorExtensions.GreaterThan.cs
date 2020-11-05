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
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThan(this long? number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThan(this long number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThan(this ValidatorStructResult<long> result, long numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThan(this int? number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThan(this int number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThan(this ValidatorStructResult<int> result, int numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThan(this short? number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThan(this short number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThan(this ValidatorStructResult<short> result, short numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThan(this byte? number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThan(this byte number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThan(this ValidatorStructResult<byte> result, byte numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThan(this decimal? number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThan(this decimal number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThan(this ValidatorStructResult<decimal> result, decimal numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThan(this float? number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThan(this float number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThan(this ValidatorStructResult<float> result, float numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThan(this double? number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThan(this double number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).GreaterThan(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThan(this ValidatorStructResult<double> result, double numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThan(this DateTime? data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).GreaterThan(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThan(this DateTime data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).GreaterThan(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior que o valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThan(this ValidatorStructResult<DateTime> result, DateTime dataCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanValidator(result.OriginalValue, dataCompare, errorMsg));
    }
}