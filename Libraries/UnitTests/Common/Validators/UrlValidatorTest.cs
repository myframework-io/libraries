using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class UrlValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Url valid")]
        [InlineData("http://www.google.com")]
        [InlineData("http://www.google.com.br")]
        [InlineData("http://www.google.com.br/teste/teste")]
        [InlineData("https://www.google.com")]
        [InlineData("https://www.google.com.br")]
        [InlineData("https://www.google.com.br/teste/teste")]
        [InlineData("https://google.com.br/teste/teste")]
        public void UrlValid(string email, string errorMsg = customMsg) => AssertValidResult(email.Url(errorMsg));

        [Theory(DisplayName = "Url invalid")]
        [InlineData("www.google.com")]
        [InlineData("www.google.com.br")]
        [InlineData("www.google.com.br/teste/teste")]
        [InlineData("google")]
        [InlineData("google.com.br")]
        [InlineData("br/teste/teste")]
        public void UrlInvalid(string email, string errorMsg = customMsg) => AssertInvalidResult(email.Url(errorMsg), errorMsg);

        [Theory(DisplayName = "Null string should not be validated")]
        [InlineData(null)]
        [InlineData(null, "another error msg")]
        public void NullStringShouldNotBeValidatedForValidator(string url, string errorMsg = customMsg) => AssertValidResult(url.Url(errorMsg));
    }
}