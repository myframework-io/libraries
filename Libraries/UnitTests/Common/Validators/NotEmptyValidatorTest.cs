using Myframework.Libraries.Common.Validators;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class NotEmptyValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Is not empty valid")]
        [InlineData("sdad")]
        [InlineData("   a  ")]
        public void IsNotEmptyValid(string value, string errorMsg = customMsg) => AssertValidResult(value.NotEmpty(errorMsg));

        [Theory(DisplayName = "Is not empty invalid")]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData("    ", "another error msg")]
        public void IsNotEmptyInvalid(string value, string errorMsg = customMsg) => AssertInvalidResult(value.NotEmpty(errorMsg), errorMsg);

        [Theory(DisplayName = "Null string should not be validated for NotEmptyValidator")]
        [InlineData(null)]
        public void NullStringShouldNotBeValidatedForNotEmptyValidator(string value, string errorMsg = customMsg) => AssertValidResult(value.NotEmpty(errorMsg));

        [Fact(DisplayName = "List empty")]
        public void ListEmnpty() => AssertInvalidResult(new List<string>().NotEmpty("Error msg"), "Error msg");
    }
}