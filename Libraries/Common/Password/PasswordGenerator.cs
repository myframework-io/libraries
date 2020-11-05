using Myframework.Libraries.Common.Extensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Myframework.Libraries.Common.Password
{
    /// <summary>
    /// Classe para geração de senhas.
    /// </summary>
    public class PasswordGenerator
    {
        /// <summary>
        /// Gera senha aleatória de acordo com os parâmetros passados ou usando os valores padrão.
        /// </summary>
        /// <param name="lengthPassword">Tamanho da senha. Caso não passe valor o tamanho padrão será 12</param>
        /// <param name="allowedChars">Caracteres que devem ser usados para gerar a senha. Caso não passe valor os caracteres utilizados serão <c><![CDATA[abcdefghijklmnopqrstuvxzABCDEFGHIJKLMNOPQRSTUVXZ1234567890!@#$%^&*()-=]]></c></param>
        /// <param name="ensureStrongPassword">Informar se a senha será forte ou não. Caso não passe valor será considerado senha forte</param>
        /// <returns>Senha gerada</returns>
        /// <example>
        /// <code>
        /// var senha = PasswordHelper.GenerateRandomPassword();
        /// </code>
        /// </example>
        public string GenerateRandomPassword(int lengthPassword = 12, string allowedChars = "abcdefghijklmnopqrstuvxzABCDEFGHIJKLMNOPQRSTUVXZ1234567890!@#$%^&*()-=", bool ensureStrongPassword = true)
        {
            var strB = new StringBuilder(100);
            var random = new Random();

            while (0 < lengthPassword--)
            {
                strB.Append(allowedChars[random.Next(allowedChars.Length)]);
            }

            string senha = strB.ToString();

            if (ensureStrongPassword)
                senha = EnsureStrongPassword(senha);

            return senha;
        }

        /// <summary>
        /// Gera uma senha usando SHA512.
        /// </summary>
        /// <param name="lengthPassword"></param>
        /// <param name="seed"></param>
        /// <param name="ensureStrongPassword"></param>
        /// <returns></returns>
        public string GeneratePasswordUsingSHA512(int lengthPassword = 12, string seed = null, bool ensureStrongPassword = true)
        {
            if (string.IsNullOrWhiteSpace(seed))
                seed = DateTime.Now.Ticks.ToString();

            string pass = BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(seed))).Replace("-", string.Empty);

            string password = pass.Substring(0, lengthPassword);

            if (ensureStrongPassword)
                password = EnsureStrongPassword(password);

            return password;
        }

        private string EnsureStrongPassword(string password)
        {
            var random = new Random();

            if (!password.HasUppercaseChar())
            {
                char[] upperCaseLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Z' };

                foreach (char caractere in upperCaseLetters)
                {
                    if (password.Contains(caractere))
                    {
                        password = password.Replace(caractere.ToString(), caractere.ToString().ToUpper());
                        break;
                    }
                }

                password = password.Substring(0, password.Length - 1);
                password += upperCaseLetters[random.Next(upperCaseLetters.Length)];
            }

            if (!password.HasNumberChars())
            {
                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                password = password.Substring(0, password.Length - 1);
                password += numbers[random.Next(numbers.Length)];
            }

            return password;
        }
    }
}