using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class MinLengthValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Min length valid")]
        [InlineData("sdad", 4)]
        [InlineData("sdaad", 4)]
        [InlineData("          ", 4)]
        public void IsValid(string value, int minLength, string errorMsg = customMsg) => AssertValidResult(value.MinLength(minLength, errorMsg));

        [Theory(DisplayName = "Min length invalid")]
        [InlineData("abc", 4)]
        [InlineData("abc", 4, "another error msg")]
        [InlineData("  ", 4)]
        public void IsNotValid(string value, int minLength, string errorMsg = customMsg) => AssertInvalidResult(value.MinLength(minLength, errorMsg), errorMsg);

        [Theory(DisplayName = "Null string should not be validated")]
        [InlineData(null, 4)]
        public void NullStringShouldNotBeValidatedForValidator(string value, int minLength, string errorMsg = customMsg) => AssertValidResult(value.MinLength(minLength, errorMsg));
    }
}