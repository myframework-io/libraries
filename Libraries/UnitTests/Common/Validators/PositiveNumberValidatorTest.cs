using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class PositiveNumberValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Is positive integer")]
        [InlineData(0), InlineData(1), InlineData(5), InlineData(54165)]
        public void IsPositiveInt(int value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive integer")]
        [InlineData(-1), InlineData(-10), InlineData(-315)]
        public void IsNotPositiveInt(int value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");

        [Theory(DisplayName = "Is positive long")]
        [InlineData(0), InlineData(1), InlineData(5), InlineData(54165)]
        public void IsPositiveLong(long value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive long")]
        [InlineData(-1), InlineData(-10), InlineData(-315)]
        public void IsNotPositiveLong(long value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");

        [Theory(DisplayName = "Is positive short")]
        [InlineData(0), InlineData(1), InlineData(5), InlineData(5165)]
        public void IsPositiveShort(short value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive short")]
        [InlineData(-1), InlineData(-10), InlineData(-315)]
        public void IsNotPositiveShort(short value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");

        [Theory(DisplayName = "Is positive byte")]
        [InlineData(0), InlineData(1), InlineData(5), InlineData(255)]
        public void IsPositiveByte(byte value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is positive decimal")]
        [InlineData(0), InlineData(0.1), InlineData(5.113), InlineData(54165.15246578)]
        public void IsPositiveDecimal(decimal value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive decimal")]
        [InlineData(-0.1), InlineData(-0.144), InlineData(-5.113), InlineData(-54165.15246578)]
        public void IsNotPositiveDecimal(decimal value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");

        [Theory(DisplayName = "Is positive double")]
        [InlineData(0), InlineData(0.1), InlineData(5.113), InlineData(54165.15246578)]
        public void IsPositiveDouble(double value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive double")]
        [InlineData(-0.1), InlineData(-0.144), InlineData(-5.113), InlineData(-54165.15246578)]
        public void IsNotPositiveDouble(double value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");

        [Theory(DisplayName = "Is positive float")]
        [InlineData(0), InlineData(0.1), InlineData(5.113), InlineData(54165.15246578)]
        public void IsPositiveFloat(float value) => AssertValidResult(value.PositiveNumber("Error"));

        [Theory(DisplayName = "Is not positive float")]
        [InlineData(-0.1), InlineData(-0.144), InlineData(-5.113), InlineData(-54165.15246578)]
        public void IsNotPositiveFloat(float value) => AssertInvalidResult(value.PositiveNumber("Error"), "Error");
    }
}