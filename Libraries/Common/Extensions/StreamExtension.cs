using System.IO;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para stream.
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// Retorna um array de bytes a partir de um Stream.
        /// </summary>
        /// <param name="stream">Stream que será convertido em array de bytes.</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            if (stream == null)
                return null;

            byte[] buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}