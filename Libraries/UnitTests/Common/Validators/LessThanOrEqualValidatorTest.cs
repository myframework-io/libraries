using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class LessThanOrEqualOrEqualValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Integer is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(3, 3)]
        public void IntegerValid(int value, int compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Integer is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void IntegerNotValid(int value, int compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Short is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(3, 3)]
        public void ShortValid(short value, short compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Short is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void ShortNotValid(short value, short compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Long is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(3, 3)]
        public void LongValid(long value, long compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Long is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void LongNotValid(long value, long compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Decimal is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(3, 3)]
        [InlineData(0.2, 0.2)]
        public void DecimalValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Decimal is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void DecimalNotValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Float is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(3, 3)]
        [InlineData(0.2, 0.2)]
        public void FloatValid(float value, float compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Float is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void FloatNotValid(float value, float compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Double is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        [InlineData(3, 3)]
        [InlineData(0.2, 0.2)]
        public void DoubleValid(double value, double compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Double is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        public void DoubleNotValid(double value, double compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Byte is less than or equal")]
        [InlineData(2, 3)]
        [InlineData(0, 1)]
        [InlineData(3, 3)]
        public void ByteValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "Byte is not less than or equal")]
        [InlineData(2, 1)]
        [InlineData(1, 0)]
        public void ByteNotValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "DateTime is less than or equal")]
        [MemberData(nameof(DateTimeLessThanOrEqualCases.IsValidCases), MemberType = typeof(DateTimeLessThanOrEqualCases))]
        public void DateTimeValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThanOrEqual(compareValue, errorMsg));

        [Theory(DisplayName = "DateTime is not less than or equal")]
        [MemberData(nameof(DateTimeLessThanOrEqualCases.IsNotValidCases), MemberType = typeof(DateTimeLessThanOrEqualCases))]
        public void DateTimeNotValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThanOrEqual(compareValue, errorMsg), errorMsg);
    }

    public class DateTimeLessThanOrEqualCases
    {
        public static IEnumerable<object[]> IsValidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 15)},
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 15), "another msg" },
                new object[]{ new DateTime(2018, 8, 4, 19, 35, 14), new DateTime(2018, 8, 5, 18, 35, 14)},
            };

        public static IEnumerable<object[]> IsNotValidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 6, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14)},
            };
    }
}