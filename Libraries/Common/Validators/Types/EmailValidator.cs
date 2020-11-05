using Myframework.Libraries.Common.RegexUtil;
using System.Text.RegularExpressions;

namespace Myframework.Libraries.Common.Validators.Types
{
    internal class EmailValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Invalid e-mail format.";

        public EmailValidator(string email, string msg = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                Valid = true;
            else
                Valid = Regex.IsMatch(email, RegexUteis.Email);

            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}