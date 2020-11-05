using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class CpfValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Cpf is valid")]
        [InlineData("954.653.650-48")]
        [InlineData("95465365048")]
        [InlineData("095776702-10")]
        [InlineData("631.371.234-02")]
        [InlineData("43398355447")]
        [InlineData("433.98355447")]
        [InlineData("433.983.55447")]
        public void CpfValid(string value, string errorMsg = customMsg) => AssertValidResult(value.Cpf(errorMsg));

        [Theory(DisplayName = "Cpf is invalid")]
        [InlineData("954.653.650-4")]
        [InlineData("9546535048")]
        [InlineData("11122244477")]
        [InlineData("111.222.444-77")]
        [InlineData("111.222.444-77", "another error msg")]
        [InlineData("4339.8355447")]
        public void CpfInvalid(string value, string errorMsg = customMsg) => AssertInvalidResult(value.Cpf(errorMsg), errorMsg);

        [Theory(DisplayName = "Empty or null cpf should not be validated")]
        [InlineData("")]
        [InlineData("", "another msg")]
        [InlineData(null)]
        public void CpfEmptyOrNull(string value, string errorMsg = customMsg) => AssertValidResult(value.Cpf(errorMsg));
    }
}