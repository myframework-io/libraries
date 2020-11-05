using Myframework.Libraries.Common.Extensions;
using System.ComponentModel;
using Xunit;

namespace Common.Extension
{
    public class EnumExtensionTest
    {
        public enum TesteEnum
        {
            [Description("DescItem1")]
            Item1 = 0,
            [Description("DescItem2")]
            Item2 = 1,
            [Description("DescItem3")]
            Item3 = 3,
            Item4 = 4,
            Item5 = 5,
            Item6 = 6
        }

        [Theory(DisplayName = "Is defined")]
        [InlineData(TesteEnum.Item1)]
        [InlineData(TesteEnum.Item6)]
        [InlineData((TesteEnum)3)]
        public void EnumIsDefined(TesteEnum item) => Assert.True(item.IsDefined());

        [Theory(DisplayName = "Is not defined")]
        [InlineData((TesteEnum)2)]
        [InlineData((TesteEnum)55)]
        [InlineData((TesteEnum)66)]
        public void EnumIsNotDefined(TesteEnum item) => Assert.False(item.IsDefined());

        [Theory(DisplayName = "Get description attribute")]
        [InlineData(TesteEnum.Item1, false)]
        [InlineData(TesteEnum.Item5, true)]
        public void GetAttributeTest(TesteEnum item, bool mustBeNull)
        {
            DescriptionAttribute attr = item.GetAttribute<DescriptionAttribute>();

            if (mustBeNull)
                Assert.Null(attr);
            else
                Assert.NotNull(attr);
        }

        [Theory(DisplayName = "Get description")]
        [InlineData(TesteEnum.Item1, "DescItem1")]
        [InlineData(TesteEnum.Item6, "Item6")]
        public void GetDescription(TesteEnum item, string expDescription) => Assert.Equal(expDescription, item.GetDescription());
    }
}