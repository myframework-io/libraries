using Myframework.Libraries.Common.Extensions;
using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para verificar se valor está entre outros dois, incluindo o primeiro e o último valor de comparação.
    /// </summary>
    internal class BetweenInclusiveValidator : BaseValidator
    {
        private readonly string defaultErrorMsg = "Must be between {0} and {1}.";

        public BetweenInclusiveValidator(long? number, long startNumber, long endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(int? number, int startNumber, int endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(decimal? number, decimal startNumber, decimal endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(double? number, double startNumber, double endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(float? number, float startNumber, float endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(short? number, short startNumber, short endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(byte? number, byte startNumber, byte endNumber, string msg = null)
        {
            if (!number.HasValue) { Valid = true; return; }

            Valid = number.Value.ItsBetween(startNumber, endNumber);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startNumber, endNumber);
        }

        public BetweenInclusiveValidator(DateTime? data, DateTime startDate, DateTime endDate, string msg = null)
        {
            if (!data.HasValue) { Valid = true; return; }

            Valid = data.Value.ItsBetween(startDate, endDate);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaultErrorMsg, startDate, endDate);
        }
    }
}