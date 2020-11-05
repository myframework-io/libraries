namespace Myframework.Libraries.Common.Validators.Types
{
    internal class PositiveNumberValidator : BaseValidator
    {
        private const string defaultErrorMsg = "Must be a positive number.";

        public PositiveNumberValidator(long? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(int? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(decimal? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(double? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(float? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(short? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }

        public PositiveNumberValidator(byte? number, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number >= 0;
            ErrorMessage = Valid ? null : msg ?? defaultErrorMsg;
        }
    }
}