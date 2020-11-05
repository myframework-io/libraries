using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{
    public class CnpjHelperTest
    {
        [Theory(DisplayName = "CNPJ Valid")]
        [InlineData("05.027.656/0001-11")]
        [InlineData("56.381.698/0001-97")]
        [InlineData("31.082.521/0001-69")]
        [InlineData("56.381.6980001-97")]
        [InlineData("11576500000192")]
        public void CnpjValid(string value) => Assert.True(CnpjHelper.IsCnpjValid(value));

        [Theory(DisplayName = "CNPJ Invalid")]
        [InlineData("05.027.656/0001-111")]
        [InlineData("31.082.521001-69")]
        [InlineData("56.381.69a/0001-97")]
        [InlineData("115765000a00192")]
        [InlineData("115765000001923")]
        [InlineData("")]
        [InlineData(null)]
        public void CnpjInvalid(string value) => Assert.False(CnpjHelper.IsCnpjValid(value));
    }
}