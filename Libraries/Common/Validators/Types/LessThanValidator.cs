using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se um valor é menor que o outro.
    /// </summary>
    internal class LessThanValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Must be less than {0}.";
        private const string defaultErrorMsgDate = "Must be less than {0}.";

        public LessThanValidator(long? number, long number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(int? number, int number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(decimal? number, decimal number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(double? number, double number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(float? number, float number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(short? number, short number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(byte? number, byte number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number < number2;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, number2);
        }

        public LessThanValidator(DateTime? date, DateTime comparissonDate, string msg = null)
        {
            if (!date.HasValue) { Valid = true; return; }

            Valid = date < comparissonDate;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsgDate, comparissonDate);
        }
    }
}