using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida se a string tem o número de caracteres permitidos.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> MaxLength(this string str, int maxLength, string errorMsg = null) => new ValidatorClassResult<string>(str).MaxLength(maxLength, errorMsg);

        /// <summary>
        /// Valida se a string tem o número de caracteres permitidos.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="maxLength"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> MaxLength(this ValidatorClassResult<string> result, int maxLength, string errorMsg = null) => result.AddValidator(new MaxLengthValidator(result.OriginalValue, maxLength, errorMsg));
    }
}