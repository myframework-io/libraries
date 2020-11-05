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
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThanOrEqual(this long? number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThanOrEqual(this long number, long numberCompare, string errorMsg = null)
            => new ValidatorStructResult<long>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> LessThanOrEqual(this ValidatorStructResult<long> result, long numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThanOrEqual(this int? number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThanOrEqual(this int number, int numberCompare, string errorMsg = null)
            => new ValidatorStructResult<int>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> LessThanOrEqual(this ValidatorStructResult<int> result, int numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThanOrEqual(this short? number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThanOrEqual(this short number, short numberCompare, string errorMsg = null)
            => new ValidatorStructResult<short>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> LessThanOrEqual(this ValidatorStructResult<short> result, short numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThanOrEqual(this byte? number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThanOrEqual(this byte number, byte numberCompare, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> LessThanOrEqual(this ValidatorStructResult<byte> result, byte numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThanOrEqual(this decimal? number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThanOrEqual(this decimal number, decimal numberCompare, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> LessThanOrEqual(this ValidatorStructResult<decimal> result, decimal numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThanOrEqual(this float? number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThanOrEqual(this float number, float numberCompare, string errorMsg = null)
            => new ValidatorStructResult<float>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> LessThanOrEqual(this ValidatorStructResult<float> result, float numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThanOrEqual(this double? number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThanOrEqual(this double number, double numberCompare, string errorMsg = null)
            => new ValidatorStructResult<double>(number).LessThanOrEqual(numberCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numberCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> LessThanOrEqual(this ValidatorStructResult<double> result, double numberCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, numberCompare, errorMsg));

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThanOrEqual(this DateTime? data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).LessThanOrEqual(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThanOrEqual(this DateTime data, DateTime dataCompare, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(data).LessThanOrEqual(dataCompare, errorMsg);

        /// <summary>
        /// Valida se valor é menor ou igual ao valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dataCompare"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> LessThanOrEqual(this ValidatorStructResult<DateTime> result, DateTime dataCompare, string errorMsg = null)
            => result.AddValidator(new LessThanOrEqualValidator(result.OriginalValue, dataCompare, errorMsg));
    }
}