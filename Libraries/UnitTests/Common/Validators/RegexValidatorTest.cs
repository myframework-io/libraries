using Myframework.Libraries.Common.RegexUtil;
using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class RegexValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Regex CPF valid")]
        [InlineData("954.653.650-48", RegexUteis.CPF)]
        [InlineData("95465365048", RegexUteis.CPF)]
        [InlineData("095776702-10", RegexUteis.CPF)]
        [InlineData("631.371.234-02", RegexUteis.CPF)]
        [InlineData("43398355447", RegexUteis.CPF)]
        [InlineData("433.98355447", RegexUteis.CPF)]
        [InlineData("433.983.55447", RegexUteis.CPF)]
        public void RegexCpfValid(string value, string regex, string errorMsg = customMsg) => AssertValidResult(value.RegexMatch(regex, errorMsg));

        [Theory(DisplayName = "Regex CPF invalid")]
        [InlineData("954.653.650-4", RegexUteis.CPF)]
        [InlineData("9546535048", RegexUteis.CPF)]
        [InlineData("111222a4447dd7111", RegexUteis.CPF)]
        [InlineData("111222a44dd477111", RegexUteis.CPF, "another error msg")]
        public void RegexCpfInalid(string value, string regex, string errorMsg = customMsg) => AssertInvalidResult(value.RegexMatch(regex, errorMsg), errorMsg);

        [Theory(DisplayName = "Regex email valid")]
        [InlineData("teste@teste.com.br", RegexUteis.Email)]
        [InlineData("teste@teste.com", RegexUteis.Email)]
        [InlineData("teste@tee.com", RegexUteis.Email)]
        public void RegexEmailValid(string value, string regex, string errorMsg = customMsg) => AssertValidResult(value.RegexMatch(regex, errorMsg));

        [Theory(DisplayName = "Regex email invalid")]
        [InlineData("testeteste.com.br", RegexUteis.Email)]
        [InlineData("teste@.com", RegexUteis.Email)]
        [InlineData("@aaa.com", RegexUteis.Email)]
        [InlineData("teste@tee", RegexUteis.Email)]
        public void RegexEmailInvalid(string value, string regex, string errorMsg = customMsg) => AssertInvalidResult(value.RegexMatch(regex, errorMsg), errorMsg);

        [Theory(DisplayName = "Regex tel/cel valid")]
        [InlineData("(21) 99999-9999", RegexUteis.TelephoneOrCellPhone)]
        [InlineData("(21) 3233-9999", RegexUteis.TelephoneOrCellPhone)]
        public void RegexTelValid(string value, string regex, string errorMsg = customMsg) => AssertValidResult(value.RegexMatch(regex, errorMsg));

        [Theory(DisplayName = "Regex tel/cel invalid")]
        [InlineData("21 9999-9999", RegexUteis.TelephoneOrCellPhone)]
        [InlineData("21 99999999", RegexUteis.TelephoneOrCellPhone)]
        public void RegexTelInvalid(string value, string regex, string errorMsg = customMsg) => AssertInvalidResult(value.RegexMatch(regex, errorMsg), errorMsg);
    }
}