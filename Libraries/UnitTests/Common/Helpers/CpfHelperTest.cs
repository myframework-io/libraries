using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{
    public class CpfHelperTest
    {
        [Theory(DisplayName = "CPF Valid")]
        [InlineData("094.934.560-13")]
        [InlineData("094.934.56013")]
        [InlineData("094.934560-13")]
        [InlineData("094934.560-13")]
        [InlineData("094934560-13")]
        [InlineData("547.514.850-32")]
        [InlineData("855.963.480-07")]
        [InlineData("13872503022")]
        [InlineData("12414341076")]
        [InlineData("73895152366")]
        public void CpfValid(string value) => Assert.True(CpfHelper.IsCpfValid(value));

        [Theory(DisplayName = "CPF Invalid")]
        [InlineData("0900934.560-13")]
        [InlineData("094.93a4.56013")]
        [InlineData("094.935aa4560-13")]
        [InlineData("094.560-13")]
        [InlineData("094960-13")]
        [InlineData("138703022")]
        [InlineData("1241aa4341076")]
        [InlineData("738951a52366")]
        [InlineData("7389512366")]
        [InlineData("4339.8355447")]
        [InlineData("")]
        [InlineData(null)]
        public void CpfInvalid(string value) => Assert.False(CpfHelper.IsCpfValid(value));

        [Fact]
        public void GenerateCpf()
        {
            Assert.True(CpfHelper.IsCpfValid(CpfHelper.GenerateCpf()));
            Assert.True(CpfHelper.IsCpfValid(CpfHelper.GenerateCpf()));
            Assert.True(CpfHelper.IsCpfValid(CpfHelper.GenerateCpf()));
            Assert.True(CpfHelper.IsCpfValid(CpfHelper.GenerateCpf()));
            Assert.True(CpfHelper.IsCpfValid(CpfHelper.GenerateCpf()));
        }
    }
}