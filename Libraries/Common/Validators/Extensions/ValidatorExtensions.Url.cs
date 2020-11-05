using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida a Url.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Url(this string str, string errorMsg = null) => new ValidatorClassResult<string>(str).Url(errorMsg);

        /// <summary>
        /// Valida a Url.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Url(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new UrlValidator(result.OriginalValue, errorMsg));
    }
}