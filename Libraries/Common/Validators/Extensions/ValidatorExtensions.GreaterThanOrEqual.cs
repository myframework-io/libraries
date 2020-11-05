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
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThanOrEqual(this long? number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThanOrEqual(this long number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> GreaterThanOrEqual(this ValidatorStructResult<long> result, long numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThanOrEqual(this int? number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThanOrEqual(this int number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> GreaterThanOrEqual(this ValidatorStructResult<int> result, int numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThanOrEqual(this short? number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThanOrEqual(this short number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> GreaterThanOrEqual(this ValidatorStructResult<short> result, short numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThanOrEqual(this byte? number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThanOrEqual(this byte number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> GreaterThanOrEqual(this ValidatorStructResult<byte> result, byte numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThanOrEqual(this decimal? number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThanOrEqual(this decimal number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> GreaterThanOrEqual(this ValidatorStructResult<decimal> result, decimal numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThanOrEqual(this float? number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThanOrEqual(this float number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> GreaterThanOrEqual(this ValidatorStructResult<float> result, float numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThanOrEqual(this double? number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThanOrEqual(this double number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).GreaterThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> GreaterThanOrEqual(this ValidatorStructResult<double> result, double numberCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThanOrEqual(this DateTime? data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).GreaterThanOrEqual(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThanOrEqual(this DateTime data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).GreaterThanOrEqual(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é maior ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> GreaterThanOrEqual(this ValidatorStructResult<DateTime> result, DateTime dataCompare, string errorMsg = null)
            => result.AddValidator(new GreaterThanOrEqualValidator(result.OriginalValue, dataCompare, errorMsg));
    }
}