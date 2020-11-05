using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se um valor é maior ou igual a outro.
    /// </summary>
    internal class GreaterThanOrEqualValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Must be greater than or equal to {0}.";
        private const string defaultErrorMsgDate = "Must be greater than or equal to {0}.";

        public GreaterThanOrEqualValidator(long? number, long number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(int? number, int number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(decimal? number, decimal number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(double? number, double number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(float? number, float number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(short? number, short number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(byte? number, byte number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public GreaterThanOrEqualValidator(DateTime? date, DateTime comparissonDate, string msg = null)
        {
            if (!date.HasValue) { Valid = true; return; }

            Valid = date >= comparissonDate;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsgDate, comparissonDate);
        }
    }
}