using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class GreaterThanValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Integer is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        public void IntegerValid(int value, int compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Integer is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void IntegerNotValid(int value, int compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Short is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        public void ShortValid(short value, short compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Short is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void ShortNotValid(short value, short compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Long is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        public void LongValid(long value, long compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Long is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void LongNotValid(long value, long compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Decimal is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void DecimalValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Decimal is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(0.2, 0.2)]
        public void DecimalNotValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Float is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void FloatValid(float value, float compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Float is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(0.2, 0.2)]
        public void FloatNotValid(float value, float compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Double is greater")]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void DoubleValid(double value, double compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Double is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(0.2, 0.2)]
        public void DoubleNotValid(double value, double compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Byte is greater")]
        [InlineData(3, 2)]
        [InlineData(1, 0)]
        public void ByteValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "Byte is not greater")]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        [InlineData(0, 1)]
        public void ByteNotValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "DateTime is greater")]
        [MemberData(nameof(DateTimeGreaterThanCases.IsGreaterCases), MemberType = typeof(DateTimeGreaterThanCases))]
        public void DateTimeValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThan(compareValue, errorMsg));

        [Theory(DisplayName = "DateTime is not greater")]
        [MemberData(nameof(DateTimeGreaterThanCases.IsNotGreaterCases), MemberType = typeof(DateTimeGreaterThanCases))]
        public void DateTimeNotValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThan(compareValue, errorMsg), errorMsg);
    }

    public class DateTimeGreaterThanCases
    {
        public static IEnumerable<object[]> IsGreaterCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14)},
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 6, 19, 35, 14), new DateTime(2018, 8, 5, 18, 35, 14)},
            };

        public static IEnumerable<object[]> IsNotGreaterCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 4, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14)},
            };
    }
}