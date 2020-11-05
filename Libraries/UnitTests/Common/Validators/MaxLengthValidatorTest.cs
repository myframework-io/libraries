using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class MaxLengthValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Max length valid")]
        [InlineData("sdad", 4)]
        [InlineData("sda", 4)]
        [InlineData("", 4)]
        public void IsValid(string value, int maxLength, string errorMsg = customMsg) => AssertValidResult(value.MaxLength(maxLength, errorMsg));

        [Theory(DisplayName = "Max length invalid")]
        [InlineData("sdadasdsadsad", 4)]
        [InlineData("sdadasdsadsad", 4, "another error msg")]
        [InlineData("                 ", 4)]
        public void IsNotValid(string value, int maxLength, string errorMsg = customMsg) => AssertInvalidResult(value.MaxLength(maxLength, errorMsg), errorMsg);

        [Theory(DisplayName = "Null string should not be validated")]
        [InlineData(null, 4)]
        public void NullStringShouldNotBeValidatedForValidator(string value, int maxLength, string errorMsg = customMsg) => AssertValidResult(value.MaxLength(maxLength, errorMsg));
    }
}