using Myframework.Libraries.Common.Validators.Types;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida um CPF.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Cpf(this string cpf, string errorMsg = null) => new ValidatorClassResult<string>(cpf).Cpf(errorMsg);

        /// <summary>
        /// Valida um CPF.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Cpf(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new CpfValidator(result.OriginalValue, errorMsg));
    }
}