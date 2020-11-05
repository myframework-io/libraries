//using Myframework.Libraries.Common.Enums;
//using Myframework.Libraries.Http.Messages;
//using Myframework.Libraries.Http.Messages.Monitoring;
//using ServicesClient.Messages;
//using Moq;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Net.NetworkInformation;
//using System.Text;
//using Xunit;

//namespace ServicesClient
//{
//    public class HttpClientServiceTest
//    {
//        [Fact]
//        public void SetHttpStatusAndMessageOKTest()
//        {
//            string json = @"
//            {
//                ""response"": {},
//                ""message"": ""Bem sucedido"",
//                ""validations"": [],
//                ""protocol"": ""3f2cb581-b057-4d17-93bf-460737962c3e""
//            }";

//            var protocolo = new Guid("3f2cb581-b057-4d17-93bf-460737962c3e");
//            AssertSetHttpStatusAndMessage(json, protocolo, "Bem sucedido", HttpStatusCode.OK);
//        }

//        [Fact]
//        public void SetHttpStatusAndMessageBadRequestTest()
//        {
//            string json = @"
//            {
//                ""response"": {},
//                ""message"": ""Algo errado"",
//                ""validations"": [],
//                ""protocol"": ""3f2cb581-b057-4d17-93bf-460737962c3e""
//            }";

//            var protocolo = new Guid("3f2cb581-b057-4d17-93bf-460737962c3e");
//            AssertSetHttpStatusAndMessage(json, protocolo, "Algo errado", HttpStatusCode.BadRequest);
//        }

//        [Fact]
//        public void SetHttpStatusAndMessageInternalServerErrorTest()
//        {
//            string json = @"
//            {
//                ""response"": {},
//                ""message"": ""erro"",
//                ""validations"": [],
//                ""protocol"": ""3f2cb581-b057-4d17-93bf-460737962c3e""
//            }";

//            var protocolo = new Guid("3f2cb581-b057-4d17-93bf-460737962c3e");
//            AssertSetHttpStatusAndMessage(json, protocolo, "erro", HttpStatusCode.InternalServerError);
//        }

//        [Fact]
//        public void PingTest()
//        {
//            IPStatus status = HttpClientService.Ping("http://www.google.com.br/");

//            Assert.Equal(IPStatus.Success, status);

//            status = HttpClientService.Ping("http://www.google.com.br/teste/testes/abc");

//            Assert.Equal(IPStatus.Success, status);

//            status = HttpClientService.Ping("http://www.google.com.br:9048/teste/testes/abc");

//            Assert.Equal(IPStatus.Success, status);

//            status = HttpClientService.Ping("https://www.google.com.br:9048/teste/testes/abc");

//            Assert.Equal(IPStatus.Success, status);
//        }

//        [Fact]
//        public void UrlIsReachableTest()
//        {
//            Assert.True(HttpClientService.UrlIsReachable("https://api.neoway.com.br/auth/token/check").GetAwaiter().GetResult());
//            Assert.True(HttpClientService.UrlIsReachable("http://www.google.com.br/").GetAwaiter().GetResult());
//        }

//        [Fact]
//        public void UrlIsReachableWithResultOKTest()
//        {
//            var request = new UrlIsReachableRequestMessage
//            {
//                Url = "http://www.google.com.br/",
//                TimeoutMs = 2000,
//                Protocol = Guid.NewGuid()
//            };

//            HttpResult<UrlIsReachableResponseMessage> result = HttpClientService.ReachUrl(request).GetAwaiter().GetResult();

//            Assert.Equal(HttpStatusCode.OK, result.HttpStatusCode);
//        }

//        private Mock<HttpClientService> MockHttpClientServiceWithHttpResponse(HttpStatusCode httpStatus, string json)
//        {
//            var response = new HttpResponseMessage(httpStatus)
//            {
//                Content = new StringContent(json, Encoding.UTF8, "application/json")
//            };

//            var serviceClientMock = new Mock<HttpClientService>(null, new HttpClientServiceOptions(), "http://teste.com/", SecurityProtocolType.Tls);
//            serviceClientMock
//                .Setup(it => it.SendAsync(It.IsAny<HttpClient>(), It.IsAny<HttpVerb>(), It.IsAny<string>(), It.IsAny<HttpContent>()))
//                .ReturnsAsync(response);
//            return serviceClientMock;
//        }

//        private void AssertSetHttpStatusAndMessage(string json, Guid protocolo, string msg, HttpStatusCode status)
//        {
//            Mock<HttpClientService> serviceClientMock = MockHttpClientServiceWithHttpResponse(status, json);

//            HttpClientService serviceClient = serviceClientMock.Object;

//            var request = new GetEmptyRequestMessage
//            {
//                Protocol = protocolo
//            };

//            HttpResult<GetEmptyResponseMessage> result = serviceClient.GetAsync<GetEmptyRequestMessage, GetEmptyResponseMessage>("api/teste", request).GetAwaiter().GetResult();

//            Assert.Equal(protocolo, result.Protocol);
//            Assert.Equal(status, result.HttpStatusCode);
//            Assert.Equal(msg, result.Message);
//        }
//    }
//}