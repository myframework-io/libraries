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
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenExclusive(this long? number, long startNumber, long endNumber, string errorMsg = null)
            => new ValidatorStructResult<long>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenExclusive(this long number, long startNumber, long endNumber, string errorMsg = null)
            => new ValidatorStructResult<long>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<long> BetweenExclusive(this ValidatorStructResult<long> result, long startNumber, long endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenExclusive(this int? number, int startNumber, int endNumber, string errorMsg = null)
            => new ValidatorStructResult<int>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenExclusive(this int number, int startNumber, int endNumber, string errorMsg = null)
            => new ValidatorStructResult<int>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<int> BetweenExclusive(this ValidatorStructResult<int> result, int startNumber, int endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenExclusive(this short? number, short startNumber, short endNumber, string errorMsg = null)
            => new ValidatorStructResult<short>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenExclusive(this short number, short startNumber, short endNumber, string errorMsg = null)
            => new ValidatorStructResult<short>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<short> BetweenExclusive(this ValidatorStructResult<short> result, short startNumber, short endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenExclusive(this byte? number, byte startNumber, byte endNumber, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenExclusive(this byte number, byte startNumber, byte endNumber, string errorMsg = null)
            => new ValidatorStructResult<byte>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<byte> BetweenExclusive(this ValidatorStructResult<byte> result, byte startNumber, byte endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenExclusive(this decimal? number, decimal startNumber, decimal endNumber, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenExclusive(this decimal number, decimal startNumber, decimal endNumber, string errorMsg = null)
            => new ValidatorStructResult<decimal>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<decimal> BetweenExclusive(this ValidatorStructResult<decimal> result, decimal startNumber, decimal endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenExclusive(this float? number, float startNumber, float endNumber, string errorMsg = null)
            => new ValidatorStructResult<float>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenExclusive(this float number, float startNumber, float endNumber, string errorMsg = null)
            => new ValidatorStructResult<float>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<float> BetweenExclusive(this ValidatorStructResult<float> result, float startNumber, float endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenExclusive(this double? number, double startNumber, double endNumber, string errorMsg = null)
            => new ValidatorStructResult<double>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenExclusive(this double number, double startNumber, double endNumber, string errorMsg = null)
            => new ValidatorStructResult<double>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o número está entre os outros informados, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<double> BetweenExclusive(this ValidatorStructResult<double> result, double startNumber, double endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));

        /// <summary>
        /// Valida se o data está entre as outras informadas, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenExclusive(this DateTime? number, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o data está entre as outras informadas, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenExclusive(this DateTime number, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => new ValidatorStructResult<DateTime>(number).BetweenExclusive(startNumber, endNumber, errorMsg);

        /// <summary>
        /// Valida se o data está entre as outras informadas, NÃO considerando se o número é igual ao primeiro ou segundo valor de comparação.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startNumber"></param>
        /// <param name="endNumber"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<DateTime> BetweenExclusive(this ValidatorStructResult<DateTime> result, DateTime startNumber, DateTime endNumber, string errorMsg = null)
            => result.AddValidator(new BetweenExclusiveValidator(result.OriginalValue, startNumber, endNumber, errorMsg));
    }
}