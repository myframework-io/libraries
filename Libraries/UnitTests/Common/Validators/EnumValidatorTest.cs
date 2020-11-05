using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class EnumValidatorTest : BaseValidatorTest
    {
        public enum TesteEnum { Item1 = 0, Item2 = 5, Item3 = 7 }

        [Theory(DisplayName = "Enum is defined")]
        [InlineData(TesteEnum.Item1)]
        [InlineData(TesteEnum.Item2)]
        [InlineData((TesteEnum)7)]
        public void IsDefined(TesteEnum value, string errorMsg = customMsg) => AssertValidResult(value.EnumIsDefined(errorMsg));

        [Theory(DisplayName = "Enum is not defined")]
        [InlineData((TesteEnum)2)]
        [InlineData((TesteEnum)6)]
        [InlineData((TesteEnum)8)]
        [InlineData((TesteEnum)8, "another error msg")]
        public void IsNotDefined(TesteEnum value, string errorMsg = customMsg) => AssertInvalidResult(value.EnumIsDefined(errorMsg), errorMsg);
    }
}