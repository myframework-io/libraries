using System.Text.RegularExpressions;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para regex.
    /// </summary>
    internal class RegexMatchValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Does not match to regex pattern.";

        public RegexMatchValidator(string str, string regexExpression, string msg = null)
        {
            if (str == null)
                Valid = false;
            else
                Valid = Regex.IsMatch(str, regexExpression);

            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}