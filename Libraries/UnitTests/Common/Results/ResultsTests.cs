using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Results
{
    public class ResultsTests
    {
        [Fact(DisplayName = "Default result valid")]
        public void DefaultResultValid()
        {
            var result = new Result();
            Assert.True(result.Valid);
            Assert.Equal(ResultCode.Ok, result.ResultCode);
            Assert.Empty(result.Validations);
            Assert.Equal(Constant.Success, result.Message);
        }

        [Theory(DisplayName = "Set business message result")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("Afdsafasadf")]
        public void SetBusinessMessageResult(string msg)
        {
            Result result = new Result().SetBusinessMessage(msg);
            Assert.False(result.Valid);
            Assert.Equal(ResultCode.BusinessError, result.ResultCode);
            Assert.Empty(result.Validations);
            Assert.Equal(msg, result.Message);
        }

        [Theory(DisplayName = "Set business message result with validations")]
        [InlineData("Val msg 1")]
        [InlineData("Val msg 1", "Val msg 2")]
        [InlineData("Val msg 1", "Val msg 2", "Val msg 3")]
        public void SetBusinessMessageResultWithValidations(params string[] validationsMsgs)
        {
            string errorMsg = "Some msg";
            Result result = new Result().SetBusinessMessage(errorMsg);

            int i = 0;
            foreach (string valMsg in validationsMsgs)
            {
                result.AddValidation($"Attr{i}", valMsg);

                Assert.Equal($"Attr{i}", result.Validations[i].Attribute);
                Assert.Equal(valMsg, result.Validations[i].Message);

                i++;
            }

            Assert.False(result.Valid);
            Assert.Equal(ResultCode.BusinessError, result.ResultCode);
            Assert.Equal(errorMsg, result.Message);
            Assert.Equal(validationsMsgs.Length, result.Validations.Count);
        }

        [Theory(DisplayName = "Add validation")]
        [InlineData("Attr1", "Test asda")]
        [InlineData("A", "A")]
        public void AddValidation(string attr, string msg)
        {
            Result result = new Result().AddValidation(attr, msg);

            Assert.False(result.Valid);
            Assert.Equal(ResultCode.BusinessError, result.ResultCode);
            Assert.Equal(Constant.Validations, result.Message);
            Assert.NotEmpty(result.Validations);
            Assert.Equal(attr, result.Validations[0].Attribute);
            Assert.Equal(msg, result.Validations[0].Message);
        }

        [Theory(DisplayName = "Add validation argument exception")]
        [InlineData("Attr1", null)]
        [InlineData("Attr1", "")]
        [InlineData("Attr1", "   ")]
        [InlineData(null, "Test asda")]
        [InlineData("", "Test asda")]
        [InlineData("   ", "Test asda")]
        [InlineData("", "")]
        [InlineData("   ", "   ")]
        [InlineData(null, null)]
        public void AddValidationArgumentException(string attr, string msg) => Assert.Throws<ArgumentException>(() => new Result().AddValidation(attr, msg));

        [Fact(DisplayName = "Add validation if fails")]
        public void AddValidationsIfFails()
        {
            string attribute = "Attr";
            string errorMsg = "An error msg";

            IValidatorResult validationResult = "".NotEmpty(errorMsg);
            Result result = new Result().AddValidationsIfFails(attribute, validationResult);

            Assert.False(result.Valid);
            Assert.Equal(ResultCode.BusinessError, result.ResultCode);
            Assert.Equal(Constant.Validations, result.Message);
            Assert.NotEmpty(result.Validations);
            Assert.Equal(attribute, result.Validations[0].Attribute);
            Assert.Equal(errorMsg, result.Validations[0].Message);
        }

        [Fact(DisplayName = "Not add validation if not fails")]
        public void AddValidationsIfNotFails()
        {
            string attribute = "Attr";
            string errorMsg = "An error msg";

            IValidatorResult validationResult = "".Empty(errorMsg);
            Result result = new Result().AddValidationsIfFails(attribute, validationResult);

            Assert.True(result.Valid);
            Assert.Equal(ResultCode.Ok, result.ResultCode);
            Assert.Equal(Constant.Success, result.Message);
            Assert.Empty(result.Validations);
        }

        [Fact(DisplayName = "Set from another with business error and validations in source")]
        public void SetFromAnotherWithBusinessErrorAndValidationsInSource()
        {
            Result result1 = new Result()
                .SetBusinessMessage("An error msg")
                .AddValidation("Attr1", "Another error msg")
                .AddValidation("Attr2", "Another error msg2");

            Result result = new Result().SetFromAnother(result1);

            AssertResultSetFromAnother(result1, result);
        }

        [Fact(DisplayName = "Set from another with business error and validations in target")]
        public void SetFromAnotherWithBusinessErrorAndValidationsInTarget()
        {
            var result1 = new Result();

            Result result = new Result()
                .SetBusinessMessage("An error msg")
                .AddValidation("Attr1", "Another error msg")
                .AddValidation("Attr2", "Another error msg2")
                .SetFromAnother(result1);

            AssertResultSetFromAnother(result1, result);
        }

        [Fact(DisplayName = "Set from another with sucess result")]
        public void SetFromAnotherWithSuccessResult()
        {
            Result result1 = new Result().Set(ResultCode.Ok, "An success msg");

            Result result = new Result()
                .SetBusinessMessage("An error msg")
                .SetFromAnother(result1);

            AssertResultSetFromAnother(result1, result);
        }

        [Theory(DisplayName = "Set result without validations")]
        [InlineData(ResultCode.Ok, "An msg", "An msg")]
        [InlineData(ResultCode.Ok, "", Constant.Success)]
        [InlineData(ResultCode.Ok, null, Constant.Success)]
        [InlineData(ResultCode.BusinessError, "An msg", "An msg")]
        [InlineData(ResultCode.BusinessError, "", "")]
        [InlineData(ResultCode.BusinessError, null, null)]
        [InlineData(ResultCode.GenericError, "An msg", "An msg")]
        [InlineData(ResultCode.GenericError, "", Constant.DefaultErrorMsg)]
        [InlineData(ResultCode.GenericError, null, Constant.DefaultErrorMsg)]
        public void SetResultWithoutValidation(ResultCode code, string msg, string expectedMsg)
        {
            Result result = new Result().Set(code, msg);

            if (code == ResultCode.Ok)
                Assert.True(result.Valid);
            else
                Assert.False(result.Valid);

            Assert.Equal(code, result.ResultCode);
            Assert.Empty(result.Validations);
            Assert.Equal(expectedMsg, result.Message);
        }

        [Theory(DisplayName = "Set result with validations")]
        [InlineData(ResultCode.Ok, "An msg", "An msg")]
        [InlineData(ResultCode.Ok, "", Constant.Success)]
        [InlineData(ResultCode.Ok, null, Constant.Success)]
        [InlineData(ResultCode.BusinessError, "An msg", "An msg")]
        [InlineData(ResultCode.BusinessError, "", "")]
        [InlineData(ResultCode.BusinessError, null, null)]
        [InlineData(ResultCode.GenericError, "An msg", "An msg")]
        [InlineData(ResultCode.GenericError, "", Constant.DefaultErrorMsg)]
        [InlineData(ResultCode.GenericError, null, Constant.DefaultErrorMsg)]
        public void SetResultWithValidation(ResultCode code, string msg, string expectedMsg)
        {
            Result result = new Result().Set(code, msg,
                new List<ResultValidation>
                {
                    new ResultValidation { Attribute = "Attr1", Message = "An msg1" },
                    new ResultValidation { Attribute = "Attr2", Message = "An msg2" },
                });

            if (code == ResultCode.Ok)
                Assert.True(result.Valid);
            else
                Assert.False(result.Valid);

            Assert.Equal(code, result.ResultCode);
            Assert.Equal(expectedMsg, result.Message);
            Assert.Equal(2, result.Validations.Count);
            Assert.Equal("Attr1", result.Validations[0].Attribute);
            Assert.Equal("An msg1", result.Validations[0].Message);
            Assert.Equal("Attr2", result.Validations[1].Attribute);
            Assert.Equal("An msg2", result.Validations[1].Message);
        }

        [Theory(DisplayName = "Set result with validation null")]
        [InlineData(ResultCode.Ok, "An msg", "An msg")]
        [InlineData(ResultCode.Ok, "", Constant.Success)]
        [InlineData(ResultCode.Ok, null, Constant.Success)]
        [InlineData(ResultCode.BusinessError, "An msg", "An msg")]
        [InlineData(ResultCode.BusinessError, "", "")]
        [InlineData(ResultCode.BusinessError, null, null)]
        [InlineData(ResultCode.GenericError, "An msg", "An msg")]
        [InlineData(ResultCode.GenericError, "", Constant.DefaultErrorMsg)]
        [InlineData(ResultCode.GenericError, null, Constant.DefaultErrorMsg)]
        public void SetResultWithValidationNull(ResultCode code, string msg, string expectedMsg)
        {
            Result result = new Result().Set(code, msg, null);

            if (code == ResultCode.Ok)
                Assert.True(result.Valid);
            else
                Assert.False(result.Valid);

            Assert.Equal(code, result.ResultCode);
            Assert.Empty(result.Validations);
            Assert.Equal(expectedMsg, result.Message);
            Assert.Empty(result.Validations);
        }

        [Fact(DisplayName = "To string without validation")]
        public void ToStringWithoutValidationTest()
        {
            string msg = "An message";

            var result = new Result();
            result.Set(ResultCode.Ok, msg);

            Assert.Equal(msg, result.ToString());
        }

        [Fact(DisplayName = "To string with validation")]
        public void ToStringWithValidationTest()
        {
            string msg = "An message";

            var result = new Result();
            result.SetBusinessMessage(msg);
            result.AddValidation("Attr1", "An msg for attr1");

            string expected = @"An message - Attr1: An msg for attr1";

            Assert.Equal(expected, result.ToString());
        }

        [Fact(DisplayName = "To string with validations")]
        public void ToStringWithValidationsTest()
        {
            string msg = "An message";

            var result = new Result();
            result.SetBusinessMessage(msg);
            result.AddValidation("Attr1", "An msg for attr1");
            result.AddValidation("Attr2", "An msg for attr2");
            result.AddValidation("Attr3", "An msg for attr3");

            string expected = @"An message
- Attr1: An msg for attr1
- Attr2: An msg for attr2
- Attr3: An msg for attr3";

            Assert.Equal(expected, result.ToString());
        }

        private void AssertResultSetFromAnother(Result result1, Result result)
        {
            Assert.Equal(result1.Valid, result.Valid);
            Assert.Equal(result1.Message, result.Message);
            Assert.Equal(result1.ResultCode, result.ResultCode);
            Assert.Equal(result1.Validations.Count, result.Validations.Count);

            for (int i = 0; i < result.Validations.Count; i++)
            {
                Assert.Equal(result1.Validations[i].Attribute, result.Validations[i].Attribute);
                Assert.Equal(result1.Validations[i].Message, result.Validations[i].Message);
            }
        }
    }
}