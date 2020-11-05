using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class EmptyValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Is empty valid")]
        [InlineData("")]
        [InlineData("     ")]
        public void IsEmptyValid(string value, string errorMsg = customMsg) => AssertValidResult(value.Empty(errorMsg));

        [Theory(DisplayName = "Is empty invalid")]
        [InlineData("sadsad")]
        [InlineData("  1   ")]
        [InlineData("  1   ", "another error msg")]
        public void IsEmptyInvalid(string value, string errorMsg = customMsg) => AssertInvalidResult(value.Empty(errorMsg), errorMsg);

        [Theory(DisplayName = "Null string should not be validated for EmptyValidator")]
        [InlineData(null)]
        public void NullStringShouldNotBeValidatedForEmptyValidator(string value, string errorMsg = customMsg) => AssertValidResult(value.Empty(errorMsg));
    }
}