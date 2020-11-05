using Myframework.Libraries.Common.Helpers;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para CPF.
    /// </summary>
    internal class CpfValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Invalid CPF.";

        public CpfValidator(string cpf, string msg = null)
        {
            Valid = string.IsNullOrWhiteSpace(cpf) || CpfHelper.IsCpfValid(cpf);
            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}