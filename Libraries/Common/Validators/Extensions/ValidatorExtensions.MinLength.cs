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
        /// <param name="minLength"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> MinLength(this string str, int minLength, string errorMsg = null) => new ValidatorClassResult<string>(str).MinLength(minLength, errorMsg);

        /// <summary>
        /// Valida se a string tem o número de caracteres permitidos.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="minLength"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> MinLength(this ValidatorClassResult<string> result, int minLength, string errorMsg = null) => result.AddValidator(new MinLengthValidator(result.OriginalValue, minLength, errorMsg));
    }
}