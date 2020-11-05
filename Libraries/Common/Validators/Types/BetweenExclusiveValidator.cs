using Myframework.Libraries.Common.Extensions;
using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para verificar se valor está entre outros dois, NÃO incluindo o primeiro e o último valor de comparação.
    /// </summary>
    internal class BetweenExclusiveValidator : BaseValidator
    {
        private readonly string defaulteErrorMessage = "Must be between {0} and {1}.";

        public BetweenExclusiveValidator(long? numero, long startNumber, long endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(int? numero, int startNumber, int endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(decimal? numero, decimal startNumber, decimal endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(double? numero, double startNumber, double endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(float? numero, float startNumber, float endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(short? numero, short startNumber, short endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(byte? numero, byte startNumber, byte endNumber, string msg = null)
        {
            if (!numero.HasValue) { Valid = true; return; }

            Valid = numero.Value.ItsBetween(startNumber, endNumber, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startNumber + 1, endNumber - 1);
        }

        public BetweenExclusiveValidator(DateTime? data, DateTime startDate, DateTime endDate, string msg = null)
        {
            if (!data.HasValue) { Valid = true; return; }

            Valid = data.Value.ItsBetween(startDate, endDate, false);
            ErrorMessage = Valid ? null : msg ?? string.Format(defaulteErrorMessage, startDate.AddMilliseconds(1), endDate.AddMilliseconds(-1));
        }
    }
}