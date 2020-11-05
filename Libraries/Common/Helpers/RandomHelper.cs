using System;
using System.Linq;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para randomicos.
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// Retorna um texto randômico usando os caracteres especificados.
        /// </summary>
        /// <param name="length">Tamanho do texto randômico.</param>
        /// <param name="chars">Caracteres permitidos para o randômico.</param>
        /// <returns></returns>
        public static string RandomString(int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Cria um randomico para byte.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="inclusiveMaxValue">Indica se o "maxValue" deve ser inclusivo ou exclusivo.</param>
        /// <returns></returns>
        public static byte RandomByte(byte minValue = byte.MinValue, byte maxValue = byte.MaxValue, bool inclusiveMaxValue = true)
        {
            if (minValue < byte.MinValue)
                minValue = byte.MinValue;

            if (minValue > byte.MaxValue)
                minValue = byte.MaxValue;

            if (maxValue > byte.MaxValue)
                maxValue = byte.MaxValue;

            if (maxValue < byte.MinValue)
                maxValue = byte.MinValue;

            if (minValue > maxValue)
                minValue = maxValue;

            if (inclusiveMaxValue)
                maxValue += 1;

            return (byte)new Random().Next(minValue, maxValue);
        }

        /// <summary>
        /// Cria um randomico para short.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="inclusiveMaxValue">Indica se o "maxValue" deve ser inclusivo ou exclusivo.</param>
        /// <returns></returns>
        public static short RandomShort(short minValue = short.MinValue, short maxValue = short.MaxValue, bool inclusiveMaxValue = true)
        {
            if (minValue < short.MinValue)
                minValue = short.MinValue;

            if (minValue > short.MaxValue)
                minValue = short.MaxValue;

            if (maxValue > short.MaxValue)
                maxValue = short.MaxValue;

            if (maxValue < short.MinValue)
                maxValue = short.MinValue;

            if (minValue > maxValue)
                minValue = maxValue;

            if (inclusiveMaxValue)
                maxValue += 1;

            return (short)new Random().Next(minValue, maxValue);
        }

        /// <summary>
        /// Cria um randomico para int.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="inclusiveMaxValue">Indica se o "maxValue" deve ser inclusivo ou exclusivo.</param>
        /// <returns></returns>
        public static int RandomInt(int minValue = int.MinValue, int maxValue = int.MaxValue, bool inclusiveMaxValue = true)
        {
            if (minValue < int.MinValue)
                minValue = int.MinValue;

            if (minValue > int.MaxValue)
                minValue = int.MaxValue;

            if (maxValue > int.MaxValue)
                maxValue = int.MaxValue;

            if (maxValue < int.MinValue)
                maxValue = int.MinValue;

            if (minValue > maxValue)
                minValue = maxValue;

            if (inclusiveMaxValue)
                maxValue += 1;

            return new Random().Next(minValue, maxValue);
        }

        /// <summary>
        /// Cria um randomico para int.
        /// </summary>
        /// <returns></returns>
        public static double RandomDouble() => new Random().NextDouble();

        /// <summary>
        /// Cria um randomico para float.
        /// </summary>
        /// <returns></returns>
        public static float RandomFloat()
        {
            // Not a uniform distribution w.r.t. the binary floating-point number line
            // which makes sense given that NextDouble is uniform from 0.0 to 1.0.
            // Uniform w.r.t. a continuous number line.
            //
            // The range produced by this method is 6.8e38.
            //
            // Therefore if NextDouble produces values in the range of 0.0 to 0.1
            // 10% of the time, we will only produce numbers less than 1e38 about
            // 10% of the time, which does not make sense.
            double result = (new Random().NextDouble() * (float.MaxValue - (double)float.MinValue)) + float.MinValue;
            return (float)result;
        }

        /// <summary>
        /// Cria um randomico para data.
        /// </summary>
        /// <param name="startYear"></param>
        /// <returns></returns>
        public static DateTime RandomDateTime(int startYear = 1995)
        {
            var start = new DateTime(startYear, 1, 1);
            return start.AddDays(new Random().Next(3684));
        }
    }
}