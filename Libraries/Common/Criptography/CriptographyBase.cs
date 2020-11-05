using System.Security.Cryptography;

namespace Myframework.Libraries.Common.Criptography
{
    /// <summary>
    /// Base para sustentar a criptografia utilizada nos sitemas de segurança.
    /// </summary>
    public abstract class CriptographyBase
    {
        /// <summary>
        /// Gera um salt aleatório utilizando a biblioteca <seealso cref="RandomNumberGenerator"/> baseado no BCryptGenRandom para Windows ou OpenSSL's para diferente de Windows.
        /// </summary>
        /// <param name="saltLength">O Salt deve ser, preferencialmente, do tamanho do hash, ex: 32 bytes</param>
        /// <returns>Array de bytes representando o salt</returns>
        public byte[] GenerateSalt(int saltLength)
        {
            using (var salts = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[saltLength];
                salts.GetBytes(salt);
                return salt;
            }
        }
    }
}
