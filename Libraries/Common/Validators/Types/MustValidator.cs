using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para uma função especializada.
    /// </summary>
    internal class MustValidator : BaseValidator
    {
        public MustValidator(Func<bool> func, string msg)
        {
            Valid = func != null && func();
            ErrorMessage = Valid ? null : msg;
        }
    }
}