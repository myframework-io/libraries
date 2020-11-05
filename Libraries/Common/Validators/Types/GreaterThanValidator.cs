using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para checar se um valor é maior que o outro.
    /// </summary>
    internal class GreaterThanValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Must be greater than {0}.";
        private const string defaultErrorMsgDate = "Must be greater than {0}.";

        public GreaterThanValidator(long? number, long number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(int? number, int number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(decimal? number, decimal number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(double? number, double number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(float? number, float number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(short? number, short number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(byte? number, byte number2, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number > number2;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public GreaterThanValidator(DateTime? date, DateTime comparissonDate, string msg = null)
        {
            if (!date.HasValue) { Valid = true; return; }

            Valid = date > comparissonDate;
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsgDate, comparissonDate);
        }
    }
}