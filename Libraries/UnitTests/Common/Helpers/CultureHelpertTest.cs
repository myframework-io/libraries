using Xunit;
using static Myframework.Libraries.Common.Helpers.CultureHelper;

namespace Common.Helpers
{
    public class CultureHelpertTest
    {
        [Theory(DisplayName = "Fail verify culture by code")]
        [InlineData("pt#ZZ")]
        [InlineData("pt*ZB")]
        [InlineData("zz/ZB")]
        [InlineData("zz-ZB")]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData(" ")]
        [InlineData("      ")]
        [InlineData(null)]
        public void FailVerifyCultureByCode(string code)
        {
            bool result = CheckCultureByCode(code);
            Assert.False(result);
        }

        [Theory(DisplayName = "Success verify culture by code")]
        [InlineData("pt-BR")]
        [InlineData("en-US")]
        [InlineData("fr-FR")]
        public void SuccessVerifyCultureByCode(string code)
        {
            bool result = CheckCultureByCode(code);
            Assert.True(result);
        }
    }
}
