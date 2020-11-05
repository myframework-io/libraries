using Myframework.Libraries.Common.RegexUtil;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para email.
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Gera um e-mail randômico usando os parâmetros de criação especificados.
        /// </summary>
        /// <param name="sufixo">Sufixo do e-mail ("@abc.com").</param>
        /// <param name="chars">Caracteres que disponíveis para gerar a parte randômica do e-mail.</param>
        /// <returns></returns>
        public static string Generate(string sufixo = "@randomicemail.com", string chars = "abcdefghijklmnopqrstuvwxyz0123456789")
        {
            var random = new Random();
            string value = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            return value + sufixo;
        }

        /// <summary>
        /// Retorna a validação de um e-mail. Caso o valor seja vazio, nulo ou tenha apenas espaços é retornado falso.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string value) => string.IsNullOrWhiteSpace(value) ? false : Regex.IsMatch(value.ToString(), RegexUteis.Email, RegexOptions.CultureInvariant | RegexOptions.ECMAScript);
    }
}