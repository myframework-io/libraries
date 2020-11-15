using System;
using System.Collections;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Valida se o valor não é vazio.
    /// </summary>
    internal class NotEmptyValidator : BaseValidator
    {
        private readonly string defaultErrorMsg = "Cannot be empty.";

        public NotEmptyValidator(string str, string msg = null)
        {
            if (str == null)
                Valid = true;
            else
                Valid = str.Trim() != string.Empty;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public NotEmptyValidator(Guid? guid, string msg = null)
        {
            if (!guid.HasValue)
                Valid = true;
            else
                Valid = Guid.Empty != guid;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public NotEmptyValidator(ICollection list, string msg = null)
        {
            if (list == null)
                Valid = true;
            else
                Valid = list.Count > 0;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }
    }
}