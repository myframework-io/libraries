using System;
using System.Globalization;
using System.Linq;

namespace Myframework.Libraries.Common.Helpers
{

    public static class CultureHelper
    {

        /// <summary>
        /// Verifica pelo código da cultura, se ela é válida
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool CheckCultureByCode(string code)
        {
            if (code == null || string.IsNullOrEmpty(code))
                return false;

            bool doesCultureExists = CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name, code, StringComparison.CurrentCultureIgnoreCase));

            if (!doesCultureExists)
                return false;

            try
            {
                var cultureInfo = new CultureInfo(code);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
