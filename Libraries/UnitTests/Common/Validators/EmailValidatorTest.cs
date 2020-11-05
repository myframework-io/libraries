using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class EmailValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Correct email")]
        [InlineData("alex@hot.com")]
        [InlineData("alex@hot.com", "another msg")]
        public void EmailValidatorValid(string email, string errorMsg = customMsg) => AssertValidResult(email.EmailAddress(errorMsg));

        [Theory(DisplayName = "Incorrect e-mail")]
        [InlineData("alex@aa")]
        [InlineData("alex@aa", "another msg")]
        [InlineData("alex@@aa")]
        [InlineData("@")]
        [InlineData("sadafsd")]
        public void EmailValidatorIncorrectEmail(string email, string errorMsg = customMsg) => AssertInvalidResult(email.EmailAddress(errorMsg), errorMsg);

        [Theory(DisplayName = "Empty or null email should not be validated")]
        [InlineData("")]
        [InlineData("", "another msg")]
        [InlineData(null)]
        public void EmailValidatorEmptyOrNullEmail(string email, string errorMsg = customMsg) => AssertValidResult(email.EmailAddress(errorMsg));
    }
}