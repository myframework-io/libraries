using Myframework.Libraries.Common.Extensions;
using System;
using System.Globalization;
using Xunit;

namespace Common.Extension
{
    public class DateTimeExtensionTest
    {
        [Theory(DisplayName = "Set day valid")]
        [InlineData(2018, 2, 1, 1)]
        [InlineData(2018, 2, 1, 15)]
        [InlineData(2018, 2, 1, 20)]
        public void SetDayValid(int year, int month, int day, int setDayValue) => Assert.Equal(new DateTime(year, month, setDayValue), new DateTime(year, month, day).SetDay(setDayValue));

        [Theory(DisplayName = "Set day invalid")]
        [InlineData(2018, 2, 1, 0)]
        [InlineData(2018, 2, 1, 29)]
        [InlineData(2018, 2, 1, 50)]
        [InlineData(2018, 2, 1, -1)]
        public void SetDayInvalid(int year, int month, int day, int setDayValue) => Assert.Equal(new DateTime(year, month, day), new DateTime(year, month, day).SetDay(setDayValue));

        [Theory(DisplayName = "Set month valid")]
        [InlineData(2018, 2, 1, 1)]
        [InlineData(2018, 2, 1, 5)]
        [InlineData(2018, 2, 1, 12)]
        public void SetMonthValid(int year, int month, int day, int setMonthValue) => Assert.Equal(new DateTime(year, setMonthValue, day), new DateTime(year, month, day).SetMonth(setMonthValue));

        [Theory(DisplayName = "Set month invalid")]
        [InlineData(2018, 2, 1, 0)]
        [InlineData(2018, 2, 1, 13)]
        [InlineData(2018, 2, 1, 50)]
        [InlineData(2018, 2, 1, -1)]
        public void SetMonthInvalid(int year, int month, int day, int setMonthValue) => Assert.Equal(new DateTime(year, month, day), new DateTime(year, month, day).SetMonth(setMonthValue));

        [Theory(DisplayName = "Set year valid")]
        [InlineData(2018, 2, 1, 1500)]
        [InlineData(2018, 2, 1, 2000)]
        [InlineData(2018, 2, 1, 3000)]
        public void SetYearValid(int year, int month, int day, int setYearValue) => Assert.Equal(new DateTime(setYearValue, month, day), new DateTime(year, month, day).SetYear(setYearValue));

        [Theory(DisplayName = "Set year invalid")]
        [InlineData(2018, 2, 1, 0)]
        [InlineData(2018, 2, 1, 999999999)]
        [InlineData(2018, 2, 1, -1)]
        public void SetYearInvalid(int year, int month, int day, int setYearValue) => Assert.Equal(new DateTime(year, month, day), new DateTime(year, month, day).SetYear(setYearValue));


        [Theory(DisplayName = "Diff in days")]
        [InlineData(2018, 2, 15, 0)]
        [InlineData(2018, 2, 1, 14)]
        [InlineData(2018, 1, 5, 41)]
        [InlineData(2015, 6, 25, 966)]
        [InlineData(2018, 6, 25, 130)]
        public void DiffInDays(int compareYear, int compareMonth, int compareDay, int daysDiff)
        {
            var date = new DateTime(2018, 2, 15);
            int diff = date.DiffInDays(new DateTime(compareYear, compareMonth, compareDay));

            Assert.Equal(daysDiff, diff);
        }

        [Theory(DisplayName = "Diff in months")]
        [InlineData(2018, 1, 15, 1)]
        [InlineData(2018, 2, 15, 0)]
        [InlineData(2018, 3, 15, 1)]
        [InlineData(2018, 3, 20, 1)]
        [InlineData(2017, 12, 31, 2)]
        [InlineData(2017, 12, 15, 2)]
        [InlineData(2019, 2, 18, 12)]
        public void DiffInMonths(int compareYear, int compareMonth, int compareDay, int monthsDiff)
        {
            var date = new DateTime(2018, 2, 15);
            int diff = date.DiffInMonths(new DateTime(compareYear, compareMonth, compareDay));

            Assert.Equal(monthsDiff, diff);
        }


        [Theory(DisplayName = "Diff in years")]
        [InlineData(2018, 3, 10, 5)]
        [InlineData(2018, 3, 15, 5)]
        [InlineData(2014, 3, 15, 1)]
        [InlineData(2013, 3, 15, 0)]
        [InlineData(2012, 3, 16, 1)]
        [InlineData(2012, 3, 15, 1)]
        public void DiffInYears(int compareYear, int compareMonth, int compareDay, int yearsDiff)
        {
            var date = new DateTime(2013, 3, 15);
            int diff = date.DiffInYears(new DateTime(compareYear, compareMonth, compareDay));

            Assert.Equal(yearsDiff, diff);
        }

        [Theory(DisplayName = "Get last date of month")]
        [InlineData(2018, 2, 5, 28)]
        [InlineData(2018, 12, 31, 31)]
        [InlineData(2018, 12, 15, 31)]
        public void GetLastDateOfMonth(int year, int month, int day, int lastDay)
        {
            var date = new DateTime(year, month, day);
            DateTime lastDate = date.GetLastDayOfMonth();

            Assert.Equal(new DateTime(year, month, lastDay), lastDate);
        }

        [Theory(DisplayName = "Is last date of month")]
        [InlineData(2018, 2, 28)]
        [InlineData(2018, 12, 31)]
        [InlineData(2018, 9, 30)]
        public void IsLastDateOfMonth(int year, int month, int day) => Assert.True(new DateTime(year, month, day).IsLastDayOfMonth());

        [Theory(DisplayName = "Is not last date of month")]
        [InlineData(2018, 2, 27)]
        [InlineData(2018, 12, 1)]
        [InlineData(2018, 9, 15)]
        public void IsNotLastDateOfMonth(int year, int month, int day) => Assert.False(new DateTime(year, month, day).IsLastDayOfMonth());

        [Theory(DisplayName = "Get first date of month")]
        [InlineData(2018, 2, 28)]
        [InlineData(2018, 12, 31)]
        [InlineData(2018, 12, 15)]
        [InlineData(2018, 5, 2)]
        [InlineData(2018, 4, 1)]
        public void GetFirstDateOfMonthTest(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            DateTime firstDay = date.GetFirstDayOfMonth();

            Assert.Equal(new DateTime(year, month, 1), firstDay);
        }

        [Theory(DisplayName = "Is first date of month")]
        [InlineData(2018, 2, 1)]
        [InlineData(2018, 12, 1)]
        [InlineData(2018, 5, 1)]
        [InlineData(2018, 4, 1)]
        public void IsFirstDateOfMonth(int year, int month, int day) => Assert.True(new DateTime(year, month, day).IsFirstDayOfMonth());

        [Theory(DisplayName = "Is not first date of month")]
        [InlineData(2018, 2, 28)]
        [InlineData(2018, 12, 31)]
        [InlineData(2018, 12, 15)]
        [InlineData(2018, 5, 2)]
        public void IsNotFirstDateOfMonth(int year, int month, int day) => Assert.False(new DateTime(year, month, day).IsFirstDayOfMonth());

        [Theory(DisplayName = "Days left until end of month")]
        [InlineData(2018, 2, 25, true, 4)]
        [InlineData(2018, 2, 25, false, 3)]
        [InlineData(2018, 2, 28, true, 1)]
        [InlineData(2018, 2, 28, false, 0)]
        public void DaysUntilEndOfMonth(int year, int month, int day, bool includeOneDay, int daysLeft) => Assert.Equal(daysLeft, new DateTime(year, month, day).DaysUntilEndOfMonth(includeOneDay));

        [Theory(DisplayName = "Days left until end of year")]
        [InlineData(2018, 2, 25, true, 310)]
        [InlineData(2018, 2, 25, false, 309)]
        [InlineData(2018, 2, 28, true, 307)]
        [InlineData(2018, 2, 28, false, 306)]
        [InlineData(2018, 5, 29, true, 217)]
        [InlineData(2018, 5, 29, false, 216)]
        [InlineData(2018, 12, 1, true, 31)]
        [InlineData(2018, 12, 1, false, 30)]
        public void DaysUntilEndOfYear(int year, int month, int day, bool includeOneDay, int daysLeft) => Assert.Equal(daysLeft, new DateTime(year, month, day).DaysUntilEndOfYear(includeOneDay));

        [Theory(DisplayName = "Date last hour")]
        [InlineData(2018, 2, 25, 10, 15, 20)]
        [InlineData(2018, 2, 28, 00, 00, 00)]
        [InlineData(2018, 2, 28, 23, 58, 58)]
        [InlineData(2018, 2, 28, 23, 59, 59)]
        public void GetDateLastHour(int year, int month, int day, int hour, int min, int sec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            DateTime lastHour = date.GetDateLastHour();
            Assert.Equal(new DateTime(year, month, day, 23, 59, 59), lastHour);
        }

        [Theory(DisplayName = "Calculate age")]
        [InlineData(1987, 8, 16, 0, 0, 0, 2018, 8, 15, 0, 0, 0, 30)]
        [InlineData(1987, 8, 16, 0, 0, 0, 2017, 8, 17, 0, 0, 0, 30)]
        [InlineData(1987, 8, 16, 0, 0, 0, 2017, 8, 16, 5, 5, 5, 30)]
        [InlineData(1987, 8, 16, 0, 0, 0, 2017, 8, 15, 0, 0, 0, 29)]
        [InlineData(1987, 8, 16, 0, 0, 0, 2016, 11, 12, 0, 0, 0, 29)]
        public void CalculateAgeTest(int birthYear, int birthMonth, int birthDay, int birthHour, int birthMin, int birthSec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec, int age)
        {
            var birthDate = new DateTime(birthYear, birthMonth, birthDay, birthHour, birthMin, birthSec);

            int calculatedAge = birthDate.CalculateAge(new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec));
            Assert.Equal(age, calculatedAge);
        }

        [Theory(DisplayName = "Greater than")]
        [InlineData(2018, 11, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 11, 19, 0, 0, 1, 2018, 11, 19, 0, 0, 0)]
        public void GreaterThan(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.True(date.GreaterThan(comparedDate));
        }

        [Theory(DisplayName = "Not greater than")]
        [InlineData(2018, 1, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 1)]
        public void NotGreaterThan(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.False(date.GreaterThan(comparedDate));
        }

        [Theory(DisplayName = "Greater than or equal")]
        [InlineData(2018, 11, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 11, 19, 0, 0, 1, 2018, 11, 19, 0, 0, 0)]
        [InlineData(2018, 11, 19, 0, 0, 1, 2018, 11, 19, 0, 0, 1)]
        public void GreaterThanOrEqual(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.True(date.GreaterThanOrEqual(comparedDate));
        }

        [Theory(DisplayName = "Not greater than or equal")]
        [InlineData(2018, 1, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 1)]
        public void NotGreaterThanOrEqual(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.False(date.GreaterThanOrEqual(comparedDate));
        }

        [Theory(DisplayName = "Less than")]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 11, 19, 0, 0, 0)]
        [InlineData(2018, 11, 19, 0, 0, 0, 2018, 11, 19, 0, 0, 1)]
        public void LessThan(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.True(date.LessThan(comparedDate));
        }

        [Theory(DisplayName = "Not less than")]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 1, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 2, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 1, 2018, 2, 19, 0, 0, 0)]
        public void NotLessThan(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.False(date.LessThan(comparedDate));
        }

        [Theory(DisplayName = "Less than or equal")]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 11, 19, 0, 0, 0)]
        [InlineData(2018, 11, 19, 0, 0, 0, 2018, 11, 19, 0, 0, 1)]
        [InlineData(2018, 11, 19, 0, 0, 1, 2018, 11, 19, 0, 0, 1)]
        public void LessThanOrEqual(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.True(date.LessThanOrEqual(comparedDate));
        }

        [Theory(DisplayName = "Not less than or equal")]
        [InlineData(2018, 2, 19, 0, 0, 0, 2018, 1, 19, 0, 0, 0)]
        [InlineData(2018, 2, 19, 0, 0, 1, 2018, 2, 19, 0, 0, 0)]
        public void NotLessThanOrEqual(int year, int month, int day, int hour, int min, int sec, int compareYear, int compareMonth, int compareDay, int compareHour, int compareMin, int compareSec)
        {
            var date = new DateTime(year, month, day, hour, min, sec);
            var comparedDate = new DateTime(compareYear, compareMonth, compareDay, compareHour, compareMin, compareSec);

            Assert.False(date.LessThanOrEqual(comparedDate));
        }

        [Theory(DisplayName = "Day of week name")]
        [InlineData(2018, 9, 10, "pt-br", "segunda-feira")]
        [InlineData(2018, 9, 14, "pt-br", "sexta-feira")]
        [InlineData(2018, 9, 15, "pt-br", "sábado")]
        [InlineData(2018, 9, 16, "pt-br", "domingo")]
        public void GetDayOfWeekName(int year, int month, int day, string culture, string expectedName) => Assert.Equal(expectedName, new DateTime(year, month, day).GetDayOfWeekName(ci: CultureInfo.GetCultureInfo(culture)).ToLower());

        [Theory(DisplayName = "Day of week name abbreviation")]
        [InlineData(2018, 9, 10, "pt-br", "seg")]
        [InlineData(2018, 9, 14, "pt-br", "sex")]
        [InlineData(2018, 9, 15, "pt-br", "sáb")]
        [InlineData(2018, 9, 16, "pt-br", "dom")]
        public void GetDayOfWeekNameAbbreviation(int year, int month, int day, string culture, string expectedName) => Assert.Equal(expectedName, new DateTime(year, month, day).GetDayOfWeekName(abbreviation: true, ci: CultureInfo.GetCultureInfo(culture)).ToLower());

        [Theory(DisplayName = "Month name")]
        [InlineData(2018, 2, 19, "pt-br", "fevereiro")]
        [InlineData(2018, 2, 19, "en-US", "february")]
        public void GetMonthName(int year, int month, int day, string culture, string expectedName) => Assert.Equal(expectedName, new DateTime(year, month, day).GetMonthName(ci: CultureInfo.GetCultureInfo(culture)).ToLower());

        [Theory(DisplayName = "Month name abbreviation")]
        [InlineData(2018, 2, 19, "pt-br", "fev")]
        [InlineData(2018, 2, 19, "en-US", "feb")]
        public void GetMonthNameAbbreviation(int year, int month, int day, string culture, string expectedName) => Assert.Equal(expectedName, new DateTime(year, month, day).GetMonthName(abbreviation: true, ci: CultureInfo.GetCultureInfo(culture)).ToLower());
    }
}