using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{
    public class EmailHelperTest
    {
        [Theory(DisplayName = "Valid day")]
        [InlineData(2018, 5, 8)]
        [InlineData(2018, 5, 1)]
        [InlineData(2018, 12, 31)]
        public void ValidDay(int year, int month, int day) => Assert.True(DateTimeHelper.IsValidDay(day, month, year));

    }
}