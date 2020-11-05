using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se o valor é vazio.
    /// </summary>
    internal class EmptyValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Text must be empty.";

        public EmptyValidator(string str, string msg = null)
        {
            if (str == null)
                Valid = true;
            else
                Valid = str.Trim() == string.Empty;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public EmptyValidator(Guid? guid, string msg = null)
        {
            if (!guid.HasValue)
                Valid = true;
            else
                Valid = guid == Guid.Empty;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }
    }
}