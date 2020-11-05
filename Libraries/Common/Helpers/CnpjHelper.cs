using Myframework.Libraries.Common.Extensions;
using System.Text.RegularExpressions;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para CNPJ.
    /// </summary>
    public static class CnpjHelper
    {
        /// <summary>
        /// Verifica se a string é um CNPJ.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="validateFormat"></param>
        /// <returns></returns>
        public static bool IsCnpjValid(string cnpj, bool validateFormat = true)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            if (cnpj.HasLetter())
                return false;

            if (validateFormat && !Regex.IsMatch(cnpj, RegexUtil.RegexUteis.CNPJ))
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}