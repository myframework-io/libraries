namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para length mínimo.
    /// </summary>
    internal class MinLengthValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Must be at least {0} characters long.";

        public MinLengthValidator(string str, int minLength, string msg = null)
        {
            if (str == null)
                Valid = true;
            else
                Valid = str.Length >= minLength;

            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}