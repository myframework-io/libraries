using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace Myframework.Libraries.Common.Criptography
{
    /// <summary>
    /// Representa a criptografia baseado em HMAC-SHA1.
    /// </summary>
    public class HMACSHA1 : CriptographyBase
    {
        /// <summary>
        /// Utiliza uma função de hash lenta (slow hash functions) para gerar o hash, com salt, baseado em HMAC-SHA1.
        /// </summary>
        /// <param name="value">Texto a ser hasheado</param>
        /// <param name="salt">Array de bytes representando o salt. O Salt deve ser, preferencialmente, do tamanho do hash, ex: 32 bytes</param>
        /// <param name="hashByteSize">Tamanho do hash. Ex: 32 bytes</param>
        /// <param name="iterations">Quantidade de iterações que serão realizadas para gerar o hash. Ideal usar mais de 10 mil</param>
        /// <returns>Texto rash</returns>
        public string HashWithSaltSlow(string value, byte[] salt, int hashByteSize, int iterations = 11001) => (Convert.ToBase64String(KeyDerivation.Pbkdf2(value, salt, KeyDerivationPrf.HMACSHA1, iterations, hashByteSize)));

        /// <summary>
        /// Verifica se o hash de um texto confere com o hash indicado.
        /// </summary>
        /// <param name="value">Texto a ser hasheado</param>
        /// <param name="hashValue">Hash para comparação</param>
        /// <param name="salt">Array de bytes representando o salt</param>
        /// <param name="hashByteSize">Quantidade de bytes do algoritimo de hash. Ex: HMACSHA1 = 16 bytes</param>
        /// <param name="iterations">Quantidade de iterações que serão realizadas para gerar o hash</param>
        /// <returns></returns>
        public bool Match(string value, string hashValue, byte[] salt, int hashByteSize, int iterations = 11001)
        {
            byte[] hashBytes = Convert.FromBase64String(hashValue);
            string newHash = HashWithSaltSlow(value, salt, hashByteSize, iterations);

            return hashValue == newHash;
        }
    }
}
