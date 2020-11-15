namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Valida se o valor não é null.
    /// </summary>
    internal class NotNullValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Cannot be null.";

        public NotNullValidator(object obj, string msg = null)
        {
            Valid = obj != null;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}