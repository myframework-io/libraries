﻿using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Validators
{
    public class NotNullValidatorTest : BaseValidatorTest
    {
        [Theory(DisplayName = "Is not null valid")]
        [MemberData(nameof(NotNullCases.ValidCases), MemberType = typeof(NotNullCases))]
        public void IsValid(object value, string errorMsg = customMsg) => AssertValidResult(value.NotNull(errorMsg));

        [Theory(DisplayName = "Is not null invalid")]
        [MemberData(nameof(NotNullCases.InvalidCases), MemberType = typeof(NotNullCases))]
        public void IsInvalid(object value, string errorMsg = customMsg) => AssertInvalidResult(value.NotNull(errorMsg), errorMsg);

        [Fact(DisplayName = "Is not null valid when is aggregate")]
        public void IsValidAggregate()
        {
            object teste = "teste";
            object resultObj = teste.Must(() => true, customMsg);
            ValidatorClassResult<object> result = resultObj.NotNull(customMsg);
            AssertValidResult(result);
        }

        [Fact(DisplayName = "Is not null invalid when is aggregate")]
        public void IsInvalidAggregate()
        {
            object teste = null;
            object resultObj = teste.Must(() => true, customMsg);
            ValidatorClassResult<object> result = resultObj.NotNull(customMsg);
            AssertInvalidResult(result, customMsg);
        }
    }

    public class NotNullCases
    {
        public static IEnumerable<object[]> ValidCases =>
            new List<object[]>
            {
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15) },
                new object[]{ new DateTime(2018, 8, 5, 20, 35, 15), "another error msg" },
                new object[]{ 1 },
                new object[]{ "" },
                new object[]{ new NullCases() },
                new object[]{ "dadfasdfsaf" },
            };

        public static IEnumerable<object[]> InvalidCases()
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
    }
}