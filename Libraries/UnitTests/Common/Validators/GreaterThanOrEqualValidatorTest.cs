using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class GreaterThanOrEqualOrEqualValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Integer is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        public void IntegerValid(int value, int compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Integer is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void IntegerNotValid(int value, int compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Short is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        public void ShortValid(short value, short compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Short is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void ShortNotValid(short value, short compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Long is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        public void LongValid(long value, long compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Long is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        public void LongNotValid(long value, long compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Decimal is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void DecimalValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Decimal is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void DecimalNotValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Float is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void FloatValid(float value, float compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Float is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void FloatNotValid(float value, float compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Double is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void DoubleValid(double value, double compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Double is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(-15, -2)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void DoubleNotValid(double value, double compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Byte is greater or equal")]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(1, 0)]
        public void ByteValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Byte is not greater or equal")]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        public void ByteNotValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "DateTime is greater or equal")]
        [MemberData(nameof(DateTimeGreaterThanOrEqualCases.IsGreaterCases), MemberType = typeof(DateTimeGreaterThanOrEqualCases))]
        public void DateTimeValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertValidResult(value.GreaterThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "DateTime is not greater or equal")]
        [MemberData(nameof(DateTimeGreaterThanOrEqualCases.IsNotGreaterCases), MemberType = typeof(DateTimeGreaterThanOrEqualCases))]
        public void DateTimeNotValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.GreaterThanOrEqual(compareValue, errorMsg), errorMsg);
    }

    public class DateTimeGreaterThanOrEqualCases
    {
        public static IEnumerable<object[]> IsGreaterCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14)},
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14)},
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 6, 19, 35, 14), new DateTime(2018, 8, 5, 18, 35, 14)},
            };

        public static IEnumerable<object[]> IsNotGreaterCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 13), new DateTime(2018, 8, 5, 20, 35, 14) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 13), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 4, 20, 35, 12), new DateTime(2018, 8, 5, 20, 35, 14)},
            };
    }
}