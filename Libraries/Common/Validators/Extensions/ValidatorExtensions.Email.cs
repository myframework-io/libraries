using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida um email.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> EmailAddress(this string email, string errorMsg = null) => new ValidatorClassResult<string>(email).EmailAddress(errorMsg);

        /// <summary>
        /// Valida um email.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> EmailAddress(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new EmailValidator(result.OriginalValue, errorMsg));
    }
}