using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se um valor é menor que o outro.
    /// </summary>
    internal class LessThanOrEqualValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Must be less than or equal to {0}.";
        private const string defaultErrorMsgDate = "Must be less than or equal to {0}.";

        public LessThanOrEqualValidator(long? number, long number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(int? number, int number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(decimal? number, decimal number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(double? number, double number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(float? number, float number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(short? number, short number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(byte? number, byte number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number <= number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanOrEqualValidator(DateTime? date, DateTime comparissonDate, string msg = null)
        {
            if (!date.HasValue) { Valid = true; return; }

            Valid = date <= comparissonDate;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsgDate, comparissonDate);
        }
    }
}