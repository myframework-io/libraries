using System;
using System.Collections.Generic;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para estruturas numéricas.
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this int number, int numberStart, int numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this short number, short numberStart, short numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this long number, long numberStart, long numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this byte number, byte numberStart, byte numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this decimal number, decimal numberStart, decimal numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this float number, float numberStart, float numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um número está entre os outros números informados.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberStart"></param>
        /// <param name="numberEnd"></param>
        /// <param name="inclusive">Considerar inclusive os números finais ([maior ou igual] e [menor ou igual]) ou não ([menor] e [maior]).</param>
        /// <returns></returns>
        public static bool ItsBetween(this double number, double numberStart, double numberEnd, bool inclusive = true) =>
            inclusive ? number >= numberStart && number <= numberEnd : number > numberStart && number < numberEnd;

        /// <summary>
        /// Verifica se um valor é maior que o outro.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool GreaterThan<T>(this T value1, T value2) where T : struct => Comparer<T>.Default.Compare(value1, value2) > 0;

        /// <summary>
        /// Verifica se um valor é maior ou igual a outro.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool GreaterThanOrEqual<T>(this T value1, T value2) where T : struct => Comparer<T>.Default.Compare(value1, value2) >= 0;

        /// <summary>
        /// Verifica se um valor é menor que o outro.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool LessThan<T>(this T value1, T value2) where T : struct => Comparer<T>.Default.Compare(value1, value2) < 0;

        /// <summary>
        /// Verifica se um valor é menor ou igual a outro.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool LessThanOrEqual<T>(this T value1, T value2) where T : struct => Comparer<T>.Default.Compare(value1, value2) <= 0;

        /// <summary>
        /// Baseado na função Math.Truncate, trunca o valor com a quantidade de casas decimais desejadas, sem arredondar.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static decimal TruncateDecimalPlaces(this decimal number, int decimalPlaces)
        {
            // O multiplicador e divisor devem ser iguais e determinam qts casas decimais serão mantidas
            decimal factor = Convert.ToDecimal(Math.Pow(10, decimalPlaces));
            return Math.Truncate(number * factor) / factor;
        }

        /// <summary>
        /// Baseado na função Math.Truncate, trunca o valor com a quantidade de casas decimais desejadas, sem arredondar.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double TruncateDecimalPlaces(this double number, int decimalPlaces)
        {
            // O multiplicador e divisor devem ser iguais e determinam qts casas decimais serão mantidas
            double factor = Math.Pow(10, decimalPlaces);
            return Math.Truncate(number * factor) / factor;
        }
    }
}