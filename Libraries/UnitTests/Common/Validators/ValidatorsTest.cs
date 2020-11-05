using Myframework.Libraries.Common.Validators;
using Xunit;

namespace Common.Validators
{
    public class ValidatorsTest
    {
        private readonly string customMsg = "Custom error msg";

        [Fact]
        public void CompositValidTest()
        {
            string email = "alex@hot.com";
            ValidatorClassResult<string> result = email.EmailAddress(customMsg).MinLength(3).MaxLength(12);
            Assert.True(result.Valid);
            Assert.Null(result.Message);
        }

        [Fact]
        public void CompositInvalidTest()
        {
            string email = "alex@hot.com";
            ValidatorClassResult<string> result = email.EmailAddress(customMsg).MinLength(13, "abc").MaxLength(11, "cdf");
            Assert.False(result.Valid);
            Assert.Equal("abc", result.Messages[0]);
            Assert.Equal("cdf", result.Messages[1]);
        }

        [Fact]
        public void MustValidTest()
        {
            string url = "http://teste";

            ValidatorClassResult<string> result = url.Must(() => url != null && url.StartsWith("http://"), "Inválido");

            Assert.True(result.Valid);
            Assert.Empty(result.Messages);
        }

        [Fact]
        public void MustInValidTest()
        {
            string url = "httteste";

            ValidatorClassResult<string> result = url.Must(() => url != null && url.StartsWith("http://"), "Inválido");

            Assert.False(result.Valid);
            Assert.Equal("Inválido", result.Messages[0]);
        }
    }
}