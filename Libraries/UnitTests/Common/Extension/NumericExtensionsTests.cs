using Myframework.Libraries.Common.Extensions;
using Xunit;

namespace Common.Extension
{
    public class NumericExtensionsTests
    {
        [Theory(DisplayName = "Greater than")]
        [InlineData(5, 4)]
        [InlineData(5.1, 4.1)]
        [InlineData((float)5.1, (float)4.1)]
        [InlineData(5.2, 5.1)]
        public void GreaterThan<T>(T greaterNumber, T lesserNumber)
            where T : struct => Assert.True(greaterNumber.GreaterThan(lesserNumber));

        [Theory(DisplayName = "Not greater than")]
        [InlineData(4, 5)]
        [InlineData(5, 5)]
        [InlineData(5.1, 5.2)]
        [InlineData(5.2, 5.2)]
        public void NotGreaterThan<T>(T lesserNumber, T greaterNumber)
            where T : struct => Assert.False(lesserNumber.GreaterThan(greaterNumber));

        [Theory(DisplayName = "Greater than or equal")]
        [InlineData(5, 4)]
        [InlineData(5.1, 4.1)]
        [InlineData((float)5.1, (float)4.1)]
        [InlineData(5.2, 5.1)]
        [InlineData(5, 5)]
        [InlineData(5.2, 5.2)]
        public void GreaterThanOrEqual<T>(T greaterNumber, T lesserNumber)
             where T : struct => Assert.True(greaterNumber.GreaterThanOrEqual(lesserNumber));

        [Theory(DisplayName = "Not greater than or equal")]
        [InlineData(4, 5)]
        [InlineData(5.1, 5.2)]
        public void NotGreaterThanOrEqual<T>(T lesserNumber, T greaterNumber)
            where T : struct => Assert.False(lesserNumber.GreaterThanOrEqual(greaterNumber));

        [Theory(DisplayName = "Less than")]
        [InlineData(4, 5)]
        [InlineData(4.1, 5.1)]
        [InlineData((float)4.1, (float)5.1)]
        [InlineData(5.1, 5.2)]
        public void LessThan<T>(T lessNumber, T greaterNumber)
            where T : struct => Assert.True(lessNumber.LessThan(greaterNumber));

        [Theory(DisplayName = "Not less than")]
        [InlineData(5, 4)]
        [InlineData(5, 5)]
        [InlineData(5.2, 5.1)]
        [InlineData(5.2, 5.2)]
        public void NotLessThan<T>(T greaterNumber, T lessNumber)
            where T : struct => Assert.False(greaterNumber.LessThan(lessNumber));

        [Theory(DisplayName = "Less than or equal")]
        [InlineData(4, 5)]
        [InlineData(4.1, 5.1)]
        [InlineData((float)4.1, (float)5.1)]
        [InlineData(5.1, 5.2)]
        [InlineData(5, 5)]
        [InlineData(5.2, 5.2)]
        public void LessThanOrEqual<T>(T lessNumber, T greaterNumber)
             where T : struct => Assert.True(lessNumber.LessThanOrEqual(greaterNumber));

        [Theory(DisplayName = "Not less than or equal")]
        [InlineData(5, 4)]
        [InlineData(5.2, 5.1)]
        public void NotLessThanOrEqual<T>(T greaterNumber, T lessNumber)
            where T : struct => Assert.False(greaterNumber.LessThanOrEqual(lessNumber));

        [Theory(DisplayName = "Truncate decimal places for decimal numbers")]
        [InlineData(8.513, 0, 8)]
        [InlineData(8.513, 1, 8.5)]
        [InlineData(8.513, 2, 8.51)]
        [InlineData(8.513, 3, 8.513)]
        [InlineData(8.513, 4, 8.513)]
        [InlineData(13819.8946815726, 0, 13819)]
        [InlineData(13819.8946815726, 1, 13819.8)]
        [InlineData(13819.8946815726, 2, 13819.89)]
        [InlineData(13819.8946815726, 3, 13819.894)]
        [InlineData(13819.8946815726, 4, 13819.8946)]
        [InlineData(13819.8946815726, 5, 13819.89468)]
        [InlineData(13819.8946815726, 6, 13819.894681)]
        [InlineData(13819.8946815726, 7, 13819.8946815)]
        [InlineData(13819.8946815726, 8, 13819.89468157)]
        [InlineData(13819.8946815726, 9, 13819.894681572)]
        [InlineData(13819.8946815726, 10, 13819.8946815726)]
        [InlineData(13819.8946815726, 11, 13819.8946815726)]
        [InlineData(13819.8946815726, 12, 13819.8946815726)]
        [InlineData(13819.8946815726, 13, 13819.8946815726)]
        [InlineData(13819.8946815726, 14, 13819.8946815726)]
        [InlineData(13819.8946815726, 15, 13819.8946815726)]
        [InlineData(13819.8946815726, 16, 13819.8946815726)]
        public void TruncateDecimalPlacesForDecimal(decimal number, int decimalPlaces, decimal expected) =>
            Assert.Equal(number.TruncateDecimalPlaces(decimalPlaces), expected);

        [Theory(DisplayName = "Truncate decimal places for double numbers")]
        [InlineData(8.513, 0, 8)]
        [InlineData(8.513, 1, 8.5)]
        [InlineData(8.513, 2, 8.51)]
        [InlineData(8.513, 3, 8.513)]
        [InlineData(8.513, 4, 8.513)]
        [InlineData(13819.8946815726, 0, 13819)]
        [InlineData(13819.8946815726, 1, 13819.8)]
        [InlineData(13819.8946815726, 2, 13819.89)]
        [InlineData(13819.8946815726, 3, 13819.894)]
        [InlineData(13819.8946815726, 4, 13819.8946)]
        [InlineData(13819.8946815726, 5, 13819.89468)]
        [InlineData(13819.8946815726, 6, 13819.894681)]
        [InlineData(13819.8946815726, 7, 13819.8946815)]
        [InlineData(13819.8946815726, 8, 13819.89468157)]
        [InlineData(13819.8946815726, 9, 13819.894681572)]
        [InlineData(13819.8946815726, 10, 13819.8946815726)]
        [InlineData(13819.8946815726, 11, 13819.8946815726)]
        [InlineData(13819.8946815726, 12, 13819.8946815726)]
        [InlineData(13819.8946815726, 13, 13819.8946815726)]
        [InlineData(13819.8946815726, 14, 13819.8946815726)]
        [InlineData(13819.8946815726, 15, 13819.8946815726)]
        [InlineData(13819.8946815726, 16, 13819.8946815726)]
        public void TruncateDecimalPlacesForDouble(double number, int decimalPlaces, double expected) =>
            Assert.Equal(number.TruncateDecimalPlaces(decimalPlaces), expected);
    }
}