using Myframework.Libraries.Common.Extensions;
using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se o enum pertence a lista de enum.
    /// </summary>
    internal class EnumIsDefinedValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Invalid enumeration.";

        public EnumIsDefinedValidator(Enum enumerator, string msg = null)
        {
            Valid = enumerator.IsDefined();
            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}