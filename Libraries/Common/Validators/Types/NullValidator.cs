namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Valida se o valor é null.
    /// </summary>
    internal class NullValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Must be null.";

        public NullValidator(object value, string msg = null)
        {
            Valid = value == null;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}