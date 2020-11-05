namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para length máximo.
    /// </summary>
    internal class MaxLengthValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Must have a maximum of {0} characters.";

        public MaxLengthValidator(string str, int maxLength, string msg = null)
        {
            if (str == null)
                Valid = true;
            else
                Valid = str.Length <= maxLength;

            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMessage, maxLength);
        }
    }
}