using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public abstract class BaseValidatorTest
    {
        protected const string customMsg = "Custom error msg";

        protected void AssertValidResult(IValidatorResult result)
        {
            Assert.True(result.Valid);
            Assert.Null(result.Message);
        }

        protected void AssertInvalidResult(IValidatorResult result, string errorMsgExpected)
        {
            Assert.False(result.Valid);
            Assert.Equal(errorMsgExpected, result.Message);
        }
    }
}
