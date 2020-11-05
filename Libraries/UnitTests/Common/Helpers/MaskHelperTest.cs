using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{
    public class MaskHelperTest
    {
        [Theory(DisplayName = "Mask CNPJ")]
        [InlineData("41900621000109", "41.900.621/0001-09")]
        [InlineData("419006215456465465460", "419006215456465465460")]
        [InlineData("419006210", "419006210")]
        [InlineData("4190.06210.0010/9", "41.900.621/0001-09")]
        [InlineData("4190.0621ABC0.0010/9", "4190.0621ABC0.0010/9")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void MaskCnpjTest(string value, string expectedValue) => Assert.Equal(expectedValue, MasksHelper.MaskCnpj(value));

        [Theory(DisplayName = "Mask CPF")]
        [InlineData("12478997844", "124.789.978-44")]
        [InlineData("124789", "124789")]
        [InlineData("1247899784455", "1247899784455")]
        [InlineData("124.789.97844", "124.789.978-44")]
        [InlineData("124.789.978-4466", "124.789.978-4466")]
        [InlineData("12B.78A.978-44", "12B.78A.978-44")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void MaskCPFTest(string value, string expectedValue) => Assert.Equal(expectedValue, MasksHelper.MaskCpf(value));

        [Theory(DisplayName = "Mask declaração nascido vivo")]
        [InlineData("12594752109", "12-59475210-9")]
        [InlineData("124789", "124789")]
        [InlineData("1247899784455", "1247899784455")]
        [InlineData("12-594752109", "12-59475210-9")]
        [InlineData("12-59475210-9", "12-59475210-9")]
        [InlineData("12-594AB210-9", "12-594AB210-9")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void MaskDeclaracaoNascidoVivoTest(string value, string expectedValue) => Assert.Equal(expectedValue, MasksHelper.MaskDeclaracaoNascidoVivo(value));
    }
}