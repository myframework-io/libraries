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
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenInclusive(this long? number, long startNumber, long endNumber, string errorMsg = null)
            => new ValidatorStructResult<long>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenInclusive(this long number, long startNumber, long endNumber, string errorMsg = null)
            => new ValidatorStructResult<long>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenInclusive(this ValidatorStructResult<long> result, long startNumber, long endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenInclusive(this int? number, int startNumber, int endNumber, string errorMsg = null)
            => new ValidatorStructResult<int>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenInclusive(this int number, int startNumber, int endNumber, string errorMsg = null)
            => new ValidatorStructResult<int>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenInclusive(this ValidatorStructResult<int> result, int startNumber, int endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenInclusive(this short? number, short startNumber, short endNumber, string errorMsg = null)
            => new ValidatorStructResult<short>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenInclusive(this short number, short startNumber, short endNumber, string errorMsg = null)
            => new ValidatorStructResult<short>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenInclusive(this ValidatorStructResult<short> result, short startNumber, short endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenInclusive(this byte? number, byte startNumber, byte endNumber, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenInclusive(this byte number, byte startNumber, byte endNumber, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenInclusive(this ValidatorStructResult<byte> result, byte startNumber, byte endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenInclusive(this decimal? number, decimal startNumber, decimal endNumber, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenInclusive(this decimal number, decimal startNumber, decimal endNumber, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenInclusive(this ValidatorStructResult<decimal> result, decimal startNumber, decimal endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenInclusive(this float? number, float startNumber, float endNumber, string errorMsg = null)
            => new ValidatorStructResult<float>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenInclusive(this float number, float startNumber, float endNumber, string errorMsg = null)
            => new ValidatorStructResult<float>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenInclusive(this ValidatorStructResult<float> result, float startNumber, float endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenInclusive(this double? number, double startNumber, double endNumber, string errorMsg = null)
            => new ValidatorStructResult<double>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenInclusive(this double number, double startNumber, double endNumber, string errorMsg = null)
            => new ValidatorStructResult<double>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenInclusive(this ValidatorStructResult<double> result, double startNumber, double endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se a data está entre as outras informadas, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenInclusive(this DateTime? number, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se a data está entre as outras informadas, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenInclusive(this DateTime number, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(number).BetweenInclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se a data está entre as outras informadas, considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenInclusive(this ValidatorStructResult<DateTime> result, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenInclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));
    }
}