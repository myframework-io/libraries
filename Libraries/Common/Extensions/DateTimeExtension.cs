using Myframework.Libraries.Common.Helpers;
using System;
using System.Globalization;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para o DateTime.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Clona uma data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime Clone(this DateTime data)
        {
            DateTime cloned = data;
            return cloned;
        }

        /// <summary>
        /// Cria uma nova data, baseada na primeira, modificando apenas o dia.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime date, int day)
        {
            if (!DateTimeHelper.IsValidDay(day, date.Month, date.Year))
                return date;

            return new DateTime(date.Year, date.Month, day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
        }

        /// <summary>
        /// Cria uma nova data, baseada na primeira, modificando apenas o mês.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime date, int month)
        {
            if (!DateTimeHelper.IsValidMonth(month))
                return date;

            return new DateTime(date.Year, month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
        }

        /// <summary>
        /// Cria uma nova data, baseada na primeira, modificando apenas o ano.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime date, int year)
        {
            if (!DateTimeHelper.IsValidYear(year))
                return date;

            return new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
        }

        /// <summary>
        /// Retorna a diferença, em dias, entre duas datas.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
		public static int DiffInDays(this DateTime date, DateTime compareDate)
        {
            int days = (compareDate - date).Days;
            return Math.Abs(days);
        }

        /// <summary>
        /// Retorna a diferença, em meses, entre duas datas.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        public static int DiffInMonths(this DateTime date, DateTime compareDate)
        {
            int monthsCount = ((date.Year - compareDate.Year) * 12) + date.Month - compareDate.Month;
            return Math.Abs(monthsCount);
        }

        /// <summary>
        /// Retorna a diferença, em anos, entre duas datas.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static int DiffInYears(this DateTime date, DateTime compareDate) => Math.Abs(compareDate.Year - date.Year);

        /// <summary>
        /// Retorna o último dia do mês baseado no mês e ano da data informada.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

        /// <summary>
        /// Indica se a data corresponde ao último dia do mês.
        /// </summary>
        /// <param name="date"></param>
        public static bool IsLastDayOfMonth(this DateTime date) => date.Date == date.GetLastDayOfMonth().Date;

        /// <summary>
        /// Retorna o primeiro dia do mês.
        /// </summary>
        /// <param name="date">Data</param>
        /// <returns></returns>
		public static DateTime GetFirstDayOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// Indica se a data corresponde ao primeiro dia do mês.
        /// </summary>
        /// <param name="date">Data</param>
		public static bool IsFirstDayOfMonth(this DateTime date) => date.Date == date.GetFirstDayOfMonth().Date;

        /// <summary>
        /// Retorna a quantidade de dias restantes até o final do mês.
        /// </summary>
        /// <param name="date">Data</param>
        /// <param name="includeOneDay">Incluir mais um dia</param>
        /// <returns></returns>
        public static int DaysUntilEndOfMonth(this DateTime date, bool includeOneDay)
        {
            var ultimoDiaMes = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            return Convert.ToInt32(ultimoDiaMes.Subtract(date).TotalDays) + (includeOneDay ? 1 : 0);
        }

        /// <summary>
        /// Retorna a quantidade de dias restantes até o final do ano.
        /// </summary>
        /// <param name="date">Data</param>
        /// <param name="includeOneDay">Incluir mais um dia</param>
        /// <returns></returns>
        public static int DaysUntilEndOfYear(this DateTime date, bool includeOneDay)
        {
            var ultimoDiaMes = new DateTime(date.Year, 12, DateTime.DaysInMonth(date.Year, 12));
            return Convert.ToInt32(ultimoDiaMes.Subtract(date.Date).TotalDays) + (includeOneDay ? 1 : 0);
        }

        /// <summary>
        /// Retorna a data informada, modificando a hora, minuto e segundo para seus valores máximos (23:59:59). Funciona como o DateTime.Today, mas colocando como última hora do dia.
        /// </summary>
        /// <param name="date">Data</param>
        /// <returns></returns>
        public static DateTime GetDateLastHour(this DateTime date) => new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

        /// <summary>
        /// Calcula a idade baseada na data de nascimento, com referencia para a data em que se quer saber a idade.
        /// </summary>
        /// <param name="birthDate">Data de nascimento.</param>
        /// <param name="compareDate">Data a partir da qual será feita a diferença com a data de nascimento para descobrir a idade. Caso não seja passado valor, será assumido o dia atual.</param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime birthDate, DateTime? compareDate = null)
        {
            DateTime dataNascimentoNormalizada = birthDate.Date;

            if (compareDate.HasValue)
                compareDate = compareDate.Value.Date;
            else
                compareDate = DateTime.Today;

            int idade = compareDate.Value.Year - dataNascimentoNormalizada.Year;

            if (dataNascimentoNormalizada > compareDate.Value.AddYears(-idade))
                idade--;

            return idade;
        }

        /// <summary>
        /// Verifica se a data é maior que a data de comparação.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static bool GreaterThan(this DateTime date, DateTime compareDate) => date > compareDate;

        /// <summary>
        /// Verifica se a data é maior ou igual que a data de comparação.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static bool GreaterThanOrEqual(this DateTime date, DateTime compareDate) => date >= compareDate;

        /// <summary>
        /// Verifica se a data é menor que a data de comparação.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static bool LessThan(this DateTime date, DateTime compareDate) => date < compareDate;

        /// <summary>
        /// Verifica se a data é menor ou igual que a data de comparação.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="compareDate"></param>
        /// <returns></returns>
        public static bool LessThanOrEqual(this DateTime date, DateTime compareDate) => date <= compareDate;

        /// <summary>
        /// Verifica se a data entre as datas informadas.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool ItsBetween(this DateTime date, DateTime dateStart, DateTime dateEnd, bool inclusive = true) =>
            inclusive ? date >= dateStart && date <= dateEnd : date > dateStart && date < dateEnd;

        /// <summary>
        /// Obtém o nome do dia da semana da data informada, na cultura informada. Exemplo: segunda-feira, domingo.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="abbreviation">Indica se deve retornar a abreviação do nome (false) ou o nome complete (true).</param>
        /// <param name="ci">Caso seja nula, será assumia a cultura atual (CultureInfo.CurrentCulture).</param>
        /// <returns></returns>
        public static string GetDayOfWeekName(this DateTime date, bool abbreviation = false, CultureInfo ci = null)
        {
            if (ci == null)
                ci = CultureInfo.CurrentCulture;

            return abbreviation ? ci.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek) : ci.DateTimeFormat.GetDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Obtém o nome do mês da data informada na cultura informada. Exemplo: janeiro, agosto.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="abbreviation">Indica se deve retornar a abreviação do nome (false) ou o nome complete (true).</param>
        /// <param name="ci">Caso seja nula, será assumia a cultura atual (CultureInfo.CurrentCulture).</param>
        /// <returns></returns>
        public static string GetMonthName(this DateTime date, bool abbreviation = false, CultureInfo ci = null)
        {
            if (ci == null)
                ci = CultureInfo.CurrentCulture;

            return abbreviation ? ci.DateTimeFormat.GetAbbreviatedMonthName(date.Month) : ci.DateTimeFormat.GetMonthName(date.Month);
        }
    }
}