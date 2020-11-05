using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class BetweenExclusiveValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Integer is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        public void IntegerValid(int value, int startValue, int finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Integer is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        public void IntegerNotValid(int value, int startValue, int finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Short is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        public void ShortValid(short value, short startValue, short finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Short is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        public void ShortNotValid(short value, short startValue, short finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Long is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        public void LongValid(long value, long startValue, long finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Long is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        public void LongNotValid(long value, long startValue, long finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Decimal is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        [InlineData(12.25, 12.24, 12.251)]
        public void DecimalValid(decimal value, decimal startValue, decimal finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Decimal is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        [InlineData(12.25, 12.25, 12.251)]
        public void DecimalNotValid(decimal value, decimal startValue, decimal finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Float is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        [InlineData(12.25, 12.24, 12.251)]
        public void FloatValid(float value, float startValue, float finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Float is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        [InlineData(12.25, 12.25, 12.251)]
        public void FloatNotValid(float value, float startValue, float finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Double is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        [InlineData(15, -15, 16)]
        [InlineData(-15, -20, 16)]
        [InlineData(12.25, 12.24, 12.251)]
        public void DoubleValid(double value, double startValue, double finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Double is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(17, -15, 16)]
        [InlineData(-21, -20, 16)]
        [InlineData(12.25, 12.25, 12.251)]
        public void DoubleNotValid(double value, double startValue, double finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "Byte is between")]
        [InlineData(15, 2, 16)]
        [InlineData(2, 1, 3)]
        public void ByteValid(byte value, byte startValue, byte finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "Byte is not between")]
        [InlineData(1, 2, 16)]
        [InlineData(1, 1, 3)]
        [InlineData(3, 1, 3)]
        public void ByteNotValid(byte value, byte startValue, byte finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);

        [Theory(DisplayName = "DateTime is between")]
        [MemberData(nameof(DateTimeBetweenExclusiveCases.IsBetweenCases), MemberType = typeof(DateTimeBetweenExclusiveCases))]
        public void DateTimeValid(DateTime value, DateTime startValue, DateTime finishValue, string errorMsg = customMsg) => AssertValidResult(value.BetweenExclusive(startValue, finishValue, errorMsg));

        [Theory(DisplayName = "DateTime is not between")]
        [MemberData(nameof(DateTimeBetweenExclusiveCases.IsNotBetweenCases), MemberType = typeof(DateTimeBetweenExclusiveCases))]
        public void DateTimeNotValid(DateTime value, DateTime startValue, DateTime finishValue, string errorMsg = customMsg) => AssertInvalidResult(value.BetweenExclusive(startValue, finishValue, errorMsg), errorMsg);
    }

    public class DateTimeBetweenExclusiveCases
    {
        public static IEnumerable<object[]> IsBetweenCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16), "another msg" },
                new object[]{ new DateTime(2018, 8, 5, 19, 35, 15), new DateTime(2018, 8, 5, 18, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16) },
            };

        public static IEnumerable<object[]> IsNotBetweenCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 13), new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 16), new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16), "another msg" },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 14), new DateTime(2018, 8, 5, 20, 35, 16) },
            };
    }
}