using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class NullValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Is null valid")]
        [MemberData(nameof(NullCases.ValidCases), MemberType = typeof(NullCases))]
        public void IsValid(object value, string errorMsg = customMsg) => AssertValidResult(value.Null(errorMsg));

        [Theory(DisplayName = "Is null invalid")]
        [MemberData(nameof(NullCases.InvalidCases), MemberType = typeof(NullCases))]
        public void IsInvalid(object value, string errorMsg = customMsg) => AssertInvalidResult(value.Null(errorMsg), errorMsg);

        [Fact(DisplayName = "Is null valid when is aggregate")]
        public void IsValidAggregate()
        {
            object teste = null;
            object resultObj = teste.Must(() => true, customMsg);
            ValidatorClassResult<object> result = resultObj.Null(customMsg);
            AssertValidResult(result);
        }

        [Fact(DisplayName = "Is null invalid when is aggregate")]
        public void IsInvalidAggregate()
        {
            object teste = "teste";
            object resultObj = teste.Must(() => true, customMsg);
            ValidatorClassResult<object> result = resultObj.Null(customMsg);
            AssertInvalidResult(result, customMsg);
        }
    }

    public class NullCases
    {
        public static IEnumerable<object[]> ValidCases()
        {
            DateTime? date = null;
            int? integer = null;
            string str = null;
            NullCases classe = null;

            return new List<object[]>
            {
                new object[]{ date },
                new object[]{ integer },
                new object[]{ str },
                new object[]{ classe },
            };
        }

        public static IEnumerable<object[]> InvalidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), "another error msg" },
                new object[]{ 1 },
                new object[]{ "" },
                new object[]{ new NullCases() },
                new object[]{ "dadfasdfsaf" },
            };
    }
}