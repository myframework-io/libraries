using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida se a string corresponde ao Regex.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexExpression"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> RegexMatch(this string str, string regexExpression, string errorMsg = null) => new ValidatorClassResult<string>(str).RegexMatch(regexExpression, errorMsg);

        /// <summary>
        /// Valida se a string corresponde ao Regex.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="regexExpression"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> RegexMatch(this ValidatorClassResult<string> result, string regexExpression, string errorMsg = null) => result.AddValidator(new RegexMatchValidator(result.OriginalValue, regexExpression, errorMsg));
    }
}