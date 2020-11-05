using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{
    public class DateTimeHelperTest
    {
        [Theory(DisplayName = "Valid day")]
        [InlineData(2018, 5, 8)]
        [InlineData(2018, 5, 1)]
        [InlineData(2018, 12, 31)]
        public void ValidDay(int year, int month, int day) => Assert.True(DateTimeHelper.IsValidDay(day, month, year));

        [Theory(DisplayName = "Invalid day")]
        [InlineData(2018, 5, 0)]
        [InlineData(2018, 5, 32)]
        [InlineData(2018, 2, 30)]
        public void InvalidDay(int year, int month, int day) => Assert.False(DateTimeHelper.IsValidDay(day, month, year));

        [Theory(DisplayName = "Valid month")]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(12)]
        public void ValidMonth(int month) => Assert.True(DateTimeHelper.IsValidMonth(month));

        [Theory(DisplayName = "Invalid month")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(13)]
        public void InvalidMonth(int month) => Assert.False(DateTimeHelper.IsValidMonth(month));
    }
}