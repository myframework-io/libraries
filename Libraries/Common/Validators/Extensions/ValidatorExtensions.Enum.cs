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
        /// Valida se um item de enum pertence ao enum. Ex: dado um enum TesteEnum com 3 itens, com valores 1,2,3, respectivamente, o cast (TesteEnum)5 é permitido pelo C#, mas não reflete um enum válido na lista desse enum.
        /// </summary>
        /// <param name="enumerator"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<Enum> EnumIsDefined(this Enum enumerator, string errorMsg = null) => new ValidatorClassResult<Enum>(enumerator).EnumIsDefined(errorMsg);

        /// <summary>
        /// /// Valida se um item de enum pertence ao enum. Ex: dado um enum TesteEnum com 3 itens, com valores 1,2,3, respectivamente, o cast (TesteEnum)5 é permitido pelo C#, mas não reflete um enum válido na lista desse enum.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static ValidatorClassResult<Enum> EnumIsDefined(this ValidatorClassResult<Enum> result, string errorMsg = null) => result.AddValidator(new EnumIsDefinedValidator(result.OriginalValue, errorMsg));
    }
}