//using Myframework.Libraries.Common.Helpers;
//using Myframework.Libraries.Common.Results;
//using Myframework.Libraries.Http.Messages;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using Xunit;

//namespace Services
//{

//    public class ResultTest
//    {
//        [Fact]
//        public void SetResultTest()
//        {
//            var request = new TesteMessageRequest { Teste = 1 };

//            var result = new Result<TesteMessageResponse>();

//            string msg = RandomHelper.RandomString(4);
//            var guid = Guid.NewGuid();
//            var list = new List<ResultValidation>
//            {
//                new ResultValidation{ Attribute = "teste", Message = "testeMesg" }
//            };

//            result.Set(ResultCode.BadRequest, msg, list);

//            Assert.Equal(ResultCode.BadRequest, result.ResultCode);
//            Assert.Equal(msg, result.Message);
//            Assert.Equal(guid, result.Protocol);
//            Assert.Equal(list.Count, result.Validations.Count);
//            Assert.Equal("teste", result.Validations[0].Attribute);
//            Assert.Equal("testeMesg", result.Validations[0].Message);

//            if ((int)result.ResultCode < 400)
//                Assert.True(result.Valid);
//            else
//                Assert.False(result.Valid);
//        }

//        [Fact]
//        public void ResultSetFromAnother()
//        {
//            var request = new TesteMessageRequest { Teste = 1 };

//            var result = new Result<TesteMessageResponse>(request);

//            var request2 = new TesteMessageRequest { Teste = 2 };

//            var result2 = new Result<TesteMessageResponse>(request2);
//            result2.SetHttpStatusToBadRequest("abc");
//            result2.AddValidation("teste", "teste1");

//            Assert.Same(request, result.RequestMessage);
//            Assert.Same(request2, result2.RequestMessage);

//            result.SetFromAnother(result2);

//            Assert.Equal(result2.ResultCode, result.ResultCode);
//            Assert.Equal(result2.Message, result.Message);
//            Assert.Equal(result2.Protocol, result.Protocol);
//            Assert.Equal(result2.Validations.Count, result.Validations.Count);
//            Assert.Equal(result2.Validations[0].Attribute, result.Validations[0].Attribute);
//            Assert.Equal(result2.Validations[0].Message, result.Validations[0].Message);

//            result = new Result<TesteMessageResponse>(request);
//            result.SetHttpStatusToForbidden();
//            result.AddValidation("adsasd", "fadfasf");

//            Assert.NotEqual(result2.ResultCode, result.ResultCode);
//            Assert.NotEqual(result2.Message, result.Message);
//            Assert.NotEqual(result2.Protocol, result.Protocol);
//            Assert.Equal(result2.Validations.Count, result.Validations.Count);
//            Assert.NotEqual(result2.Validations[0].Attribute, result.Validations[0].Attribute);
//            Assert.NotEqual(result2.Validations[0].Message, result.Validations[0].Message);
//        }

//        private void AssertStatusCodeAndMessage(ResultCode statusCode, Func<Result<TesteMessageResponse>, string, Guid, object> func)
//        {
//            var request = new TesteMessageRequest { Teste = 1 };
//            request.Protocol = Guid.NewGuid();

//            var result = new Result<TesteMessageResponse>(request);

//            string msg = RandomHelper.RandomString(4);
//            var protocolo = Guid.NewGuid();
//            func(result, msg, protocolo);
//            Assert.Equal(statusCode, result.ResultCode);
//            Assert.Equal(msg, result.Message);
//        }
//    }
//}