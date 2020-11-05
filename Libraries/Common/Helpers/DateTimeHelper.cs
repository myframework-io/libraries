using System;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para datas.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Verifica se o dia é válido para o mês/ano informados.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsValidDay(int day, int month, int year) => day >= 1 && day <= DateTime.DaysInMonth(year, month);

        /// <summary>
        /// Veriica se é um mês valido.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool IsValidMonth(int month) => month >= 1 && month <= 12;

        /// <summary>
        /// Verifica se é um ano válido.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsValidYear(int year) => year >= DateTime.MinValue.Year && year <= DateTime.MaxValue.Year;
    }
}