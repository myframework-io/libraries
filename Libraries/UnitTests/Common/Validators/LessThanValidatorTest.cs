using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class LessThanValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Integer is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        public void IntegerValid(int value, int compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Integer is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void IntegerNotValid(int value, int compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Short is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        public void ShortValid(short value, short compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Short is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void ShortNotValid(short value, short compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Long is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        public void LongValid(long value, long compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Long is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        public void LongNotValid(long value, long compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Decimal is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void DecimalValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Decimal is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void DecimalNotValid(decimal value, decimal compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Float is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void FloatValid(float value, float compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Float is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void FloatNotValid(float value, float compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Double is less than")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0.1, 0.2)]
        public void DoubleValid(double value, double compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Double is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(-2, -15)]
        [InlineData(0, -1)]
        [InlineData(0.2, 0.1)]
        [InlineData(0.2, 0.2)]
        public void DoubleNotValid(double value, double compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Byte is less than")]
        [InlineData(2, 3)]
        [InlineData(0, 1)]
        public void ByteValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "Byte is not less than")]
        [InlineData(2, 1)]
        [InlineData(3, 3)]
        [InlineData(1, 0)]
        public void ByteNotValid(byte value, byte compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);

        [Theory(DisplayName = "DateTime is less than")]
        [MemberData(nameof(DateTimeLessThanCases.IsValidCases), MemberType = typeof(DateTimeLessThanCases))]
        public void DateTimeValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertValidResult(value.LessThan(compareValue, errorMsg));

        [Theory(DisplayName = "DateTime is not less than")]
        [MemberData(nameof(DateTimeLessThanCases.IsNotValidCases), MemberType = typeof(DateTimeLessThanCases))]
        public void DateTimeNotValid(DateTime value, DateTime compareValue, string errorMsg = customMsg) => AssertInvalidResult(value.LessThan(compareValue, errorMsg), errorMsg);
    }

    public class DateTimeLessThanCases
    {
        public static IEnumerable<object[]> IsValidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 15)},
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 15), "another msg" },
                new object[]{ new DateTime(2018, 8, 4, 19, 35, 14), new DateTime(2018, 8, 5, 18, 35, 14)},
            };

        public static IEnumerable<object[]> IsNotValidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14), "another msg" },
                new object[]{ new DateTime(2018, 8, 6, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14)},
            };
    }
}