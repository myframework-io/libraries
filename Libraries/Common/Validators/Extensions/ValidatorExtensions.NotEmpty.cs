using Myframework.Libraries.Common.Validators.Types;
using System;
using System.Collections;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Extensões para aplicar validadores.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Valida se o valor não é vazio.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> NotEmpty(this string str, string errorMsg = null) => new ValidatorClassResult<string>(str).NotEmpty(errorMsg);

        /// <summary>
        /// Valida se o valor não é vazio. 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<string> NotEmpty(this ValidatorClassResult<string> result, string errorMsg = null) => result.AddValidator(new NotEmptyValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se o valor não é vazio.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotEmpty(this Guid? guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).NotEmpty(errorMsg);

        /// <summary>
        /// Valida se o valor não é vazio.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotEmpty(this Guid guid, string errorMsg = null) => new ValidatorStructResult<Guid>(guid).NotEmpty(errorMsg);

        /// <summary>
        /// Valida se o valor não é vazio.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorStructResult<Guid> NotEmpty(this ValidatorStructResult<Guid> result, string errorMsg = null) => result.AddValidator(new NotEmptyValidator(result.OriginalValue, errorMsg));

        /// <summary>
        /// Valida se a lista não é vazia.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<ICollection> NotEmpty(this ICollection collection, string errorMsg = null) => new ValidatorClassResult<ICollection>(collection).NotEmpty(errorMsg);

        /// <summary>
        /// Valida se a lista não é vazia.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<ICollection> NotEmpty(this ValidatorClassResult<ICollection> result, string errorMsg = null) => result.AddValidator(new NotEmptyValidator(result.OriginalValue, errorMsg));
    }
}