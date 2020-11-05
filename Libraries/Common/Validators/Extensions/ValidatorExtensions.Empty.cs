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
        /// Valida se o valor está vazio.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Empty(this string str, string errorMsg = null) => new ValidatorClassResult<string>(str).Empty(errorMsg);

        /// <summary>
        /// Valida se o valor está vazio.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> Empty(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new EmptyValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor está vazio.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Empty(this Guid? guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).Empty(errorMsg);

        /// <summary>
        /// Valida se o valor está vazio.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Empty(this Guid guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).Empty(errorMsg);

        /// <summary>
        /// Valida se o valor está vazio.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> Empty(this ValidatorStructResult<Guid> result, string errorMsg = null) => result.AddValidator(new EmptyValidator(result.OriginalValue, errorMsg));
    }
}