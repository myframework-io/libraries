// using Myframework.Libraries.Application.Middlewares;
// using Myframework.Libraries.Application.Options;
// using Myframework.Libraries.Common.Constants;
// using Myframework.Libraries.Common.Results;
// using Myframework.Libraries.Infra.Log.Contracts;
// using Myframework.Libraries.Infra.Security;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Caching.Memory;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using Moq;
// using Moq.Protected;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Net;
// using System.Net.Http;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using Xunit;

// namespace Application.Middlewares
// {
//     public class TranslationMiddlewareTest
//     {
//         private readonly Mock<RequestDelegate> nextMiddlewareInPipelineDelegateMock;
//         private readonly Mock<IClientTokenManager> tokenManagerMock;
//         private readonly Mock<ILogger<TranslationMiddleware>> loggerMock;
//         private readonly Mock<IErrorLogger> errorLoggerMock;
//         private readonly IMemoryCache memoryCache;
//         private readonly Mock<IHttpClientFactory> httpClientFactoryMock;
//         private readonly HttpClient defaultHttpClient;
//         private readonly Mock<HttpResponseMessage> responseMock;
//         private readonly IOptions<TranslationOptions> translateOptionsMock;
//         private readonly IOptions<GlobalizationOptions> globalizationOptionsMock;
//         private readonly DefaultHttpContext httpContextMock;
//         private readonly TranslationMiddleware translationMiddleware;
//         private readonly Mock<HttpMessageHandler> handlerMock;
//         private Result resultTranslatedPtBr;

//         public TranslationMiddlewareTest()
//         {
//             nextMiddlewareInPipelineDelegateMock = new Mock<RequestDelegate>();
//             tokenManagerMock = new Mock<IClientTokenManager>();
//             loggerMock = new Mock<ILogger<TranslationMiddleware>>();
//             errorLoggerMock = new Mock<IErrorLogger>();
//             memoryCache = new MemoryCache(new MemoryCacheOptions());
//             httpClientFactoryMock = new Mock<IHttpClientFactory>();
//             httpContextMock = new DefaultHttpContext();
//             httpContextMock.Response.Body = new MemoryStream();
//             httpContextMock.Request.Headers.Add("Accept-Language", "pt-BR");

//             tokenManagerMock.Setup(it => it.GetAccessTokenAsync()).ReturnsAsync(new Result<string> { Value = "some token" });

//             translateOptionsMock = Options.Create(
//                 new TranslationOptions
//                 {
//                     BaseUrl = "https://globalization.Myframeworkmonitor.com/",
//                     ResultTranslateRoute = "api/terms/results",
//                     Enabled = true,
//                     ApiTimeout = new System.TimeSpan(0, 5, 0),
//                     CacheTimeoutForSuccessResultTranslation = new System.TimeSpan(2, 0, 0),
//                     ThrowExceptionWhenErrorOcurrInTranslate = false
//                 });

//             globalizationOptionsMock = Options.Create(
//                 new GlobalizationOptions
//                 {
//                     DefaultRequestCulture = null,
//                     SupportedCultures = null,
//                     SupportedUICultures = null,
//                     UseQueryStringRequestCultureProvider = false
//                 });


//             resultTranslatedPtBr = new Result().Set(ResultCode.Ok, "Sucesso");
//             responseMock = new Mock<HttpResponseMessage>();
//             responseMock.Object.StatusCode = HttpStatusCode.OK;
//             responseMock.Object.Content = new StringContent(JsonConvert.SerializeObject(resultTranslatedPtBr), Encoding.UTF8, "application/json");

//             handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
//             handlerMock
//                .Protected()
//                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//                .ReturnsAsync(responseMock.Object)
//                .Verifiable();

//             defaultHttpClient = new HttpClient(handlerMock.Object);

//             httpClientFactoryMock.Setup(it => it.CreateClient(It.IsAny<string>())).Returns(defaultHttpClient);

//             translationMiddleware = new TranslationMiddleware(nextMiddlewareInPipelineDelegateMock.Object, tokenManagerMock.Object, loggerMock.Object, errorLoggerMock.Object, translateOptionsMock, globalizationOptionsMock, memoryCache, httpClientFactoryMock.Object);
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR valid empty result")]
//         public async Task SuccessfulyTranslateForPtBRValidEmptyResult()
//         {
//             var resultFromPipeline = new Result();

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultTranslatedPtBr.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Equal(resultTranslatedPtBr.Message, memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR valid empty result from cache")]
//         public async Task SuccessfulyTranslateForPtBRValidEmptyResultFromCache()
//         {
//             var resultFromPipeline = new Result();
//             string messageInCache = "Sucesso msg test";

//             using (ICacheEntry entryCache = memoryCache.CreateEntry($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"))
//             {
//                 entryCache.Value = messageInCache;
//                 entryCache.AbsoluteExpirationRelativeToNow = translateOptionsMock.Value.CacheTimeoutForSuccessResultTranslation;
//             }

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(messageInCache, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Equal(messageInCache, memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR valid not empty result")]
//         public async Task SuccessfulyTranslateForPtBRValidNotEmptyResult()
//         {
//             var resultFromPipeline = new Result<List<TestViewModel>>
//             {
//                 Value = new List<TestViewModel>
//                 {
//                     new TestViewModel { Prop1 = 1, Prop2 = "teste 1", Prop3 = new DateTime(2020, 5, 1) },
//                     new TestViewModel { Prop1 = 2, Prop2 = "teste 2", Prop3 = new DateTime(2020, 5, 2) },
//                 }
//             };

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result<List<TestViewModel>> resultAfterTranslation = ExtractResultFromResponseBody<Result<List<TestViewModel>>>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultTranslatedPtBr.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Equal(resultTranslatedPtBr.Message, memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));

//             Assert.Equal(resultFromPipeline.Value.Count, resultAfterTranslation.Value.Count);
//             Assert.Equal(resultFromPipeline.Value[0].Prop1, resultAfterTranslation.Value[0].Prop1);
//             Assert.Equal(resultFromPipeline.Value[0].Prop2, resultAfterTranslation.Value[0].Prop2);
//             Assert.Equal(resultFromPipeline.Value[0].Prop3, resultAfterTranslation.Value[0].Prop3);
//             Assert.Equal(resultFromPipeline.Value[1].Prop1, resultAfterTranslation.Value[1].Prop1);
//             Assert.Equal(resultFromPipeline.Value[1].Prop2, resultAfterTranslation.Value[1].Prop2);
//             Assert.Equal(resultFromPipeline.Value[1].Prop3, resultAfterTranslation.Value[1].Prop3);
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR valid not empty result from cache")]
//         public async Task SuccessfulyTranslateForPtBRValidNotEmptyResultFromCache()
//         {
//             var resultFromPipeline = new Result<List<TestViewModel>>
//             {
//                 Value = new List<TestViewModel>
//                 {
//                     new TestViewModel { Prop1 = 1, Prop2 = "teste 1", Prop3 = new DateTime(2020, 5, 1) },
//                     new TestViewModel { Prop1 = 2, Prop2 = "teste 2", Prop3 = new DateTime(2020, 5, 2) },
//                 }
//             };

//             string messageInCache = "Sucesso msg test";

//             using (ICacheEntry entryCache = memoryCache.CreateEntry($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"))
//             {
//                 entryCache.Value = messageInCache;
//                 entryCache.AbsoluteExpirationRelativeToNow = translateOptionsMock.Value.CacheTimeoutForSuccessResultTranslation;
//             }

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result<List<TestViewModel>> resultAfterTranslation = ExtractResultFromResponseBody<Result<List<TestViewModel>>>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(messageInCache, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Equal(messageInCache, memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));

//             Assert.Equal(resultFromPipeline.Value.Count, resultAfterTranslation.Value.Count);
//             Assert.Equal(resultFromPipeline.Value[0].Prop1, resultAfterTranslation.Value[0].Prop1);
//             Assert.Equal(resultFromPipeline.Value[0].Prop2, resultAfterTranslation.Value[0].Prop2);
//             Assert.Equal(resultFromPipeline.Value[0].Prop3, resultAfterTranslation.Value[0].Prop3);
//             Assert.Equal(resultFromPipeline.Value[1].Prop1, resultAfterTranslation.Value[1].Prop1);
//             Assert.Equal(resultFromPipeline.Value[1].Prop2, resultAfterTranslation.Value[1].Prop2);
//             Assert.Equal(resultFromPipeline.Value[1].Prop3, resultAfterTranslation.Value[1].Prop3);
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR not valid empty result and no validations")]
//         public async Task SuccessfulyTranslateForPtBRNotValidEmptyResultAndNoValidations()
//         {
//             Result resultFromPipeline = new Result().SetBusinessMessage("Something is wrong");

//             resultTranslatedPtBr = new Result().Set(ResultCode.Ok, "Algo está errado");
//             responseMock.Object.StatusCode = HttpStatusCode.OK;
//             responseMock.Object.Content = new StringContent(JsonConvert.SerializeObject(resultTranslatedPtBr), Encoding.UTF8, "application/json");

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() =>
//                 {
//                     httpContextMock.Response.StatusCode = 422;
//                     WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline);
//                 });

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultTranslatedPtBr.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR not valid empty result and validations")]
//         public async Task SuccessfulyTranslateForPtBRNotValidEmptyResultAndValidations()
//         {
//             Result resultFromPipeline = new Result().SetBusinessMessage("Validations");
//             resultFromPipeline.AddValidation("Name", "Cannot be null.");
//             resultFromPipeline.AddValidation("Age", "Cannot be empty.");

//             resultTranslatedPtBr = new Result();
//             resultTranslatedPtBr.AddValidation("Nome", "Não pode ser nulo.");
//             resultTranslatedPtBr.AddValidation("Idade", "Não pode ser vazia.");
//             resultTranslatedPtBr.Set(ResultCode.BusinessError, "Validações", resultTranslatedPtBr.Validations);

//             responseMock.Object.StatusCode = HttpStatusCode.OK;
//             responseMock.Object.Content = new StringContent(JsonConvert.SerializeObject(resultTranslatedPtBr), Encoding.UTF8, "application/json");

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() =>
//                 {
//                     httpContextMock.Response.StatusCode = 422;
//                     WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline);
//                 });

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultTranslatedPtBr.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Validations[0].Attribute, resultAfterTranslation.Validations[0].Attribute);
//             Assert.Equal(resultFromPipeline.Validations[0].Message, resultAfterTranslation.Validations[0].Message);
//             Assert.Equal(resultFromPipeline.Validations[1].Attribute, resultAfterTranslation.Validations[1].Attribute);
//             Assert.Equal(resultFromPipeline.Validations[1].Message, resultAfterTranslation.Validations[1].Message);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Successfuly translate for pt-BR error result")]
//         public async Task SuccessfulyTranslateForPtBRErrorResult()
//         {
//             Result resultFromPipeline = new Result().Set(ResultCode.GenericError, "Unexpected error.");

//             resultTranslatedPtBr = new Result().Set(ResultCode.GenericError, "Erro inexperado.");

//             responseMock.Object.StatusCode = HttpStatusCode.OK;
//             responseMock.Object.Content = new StringContent(JsonConvert.SerializeObject(resultTranslatedPtBr), Encoding.UTF8, "application/json");

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() =>
//                 {
//                     httpContextMock.Response.StatusCode = 500;
//                     WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline);
//                 });

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.NotEqual(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultTranslatedPtBr.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Unauthorize in globalization HTTP")]
//         public async Task ErrorInHttpOnCallingGlobalization()
//         {
//             var resultFromPipeline = new Result();

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             responseMock.Object.StatusCode = HttpStatusCode.Unauthorized;
//             responseMock.Object.Content = new StringContent("", Encoding.UTF8, "application/json");

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Once);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.Equal(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Not translate because accept language header is missing")]
//         public async Task NotTranslateBecauseAcceptLanguageHeaderIsMissing()
//         {
//             var resultFromPipeline = new Result();

//             httpContextMock.Request.Headers.Remove("Accept-Language");

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.Equal(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Not translate because accept language header is default language")]
//         public async Task NotTranslateBecauseAcceptLanguageHeaderIsDefaultLanguage()
//         {
//             var resultFromPipeline = new Result();

//             httpContextMock.Request.Headers.Remove("Accept-Language");
//             httpContextMock.Request.Headers.Add("Accept-Language", "en-US");

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.Equal(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Not translate because option enable false")]
//         public async Task NotTranslateBecauseOptionEnableFalse()
//         {
//             var resultFromPipeline = new Result();

//             translateOptionsMock.Value.Enabled = false;

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, resultFromPipeline));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.Equal(resultFromPipeline.Message, resultAfterTranslation.Message);
//             Assert.Equal(resultFromPipeline.Validations.Count, resultAfterTranslation.Validations.Count);
//             Assert.Equal(resultFromPipeline.Valid, resultAfterTranslation.Valid);
//             Assert.Equal(resultFromPipeline.ResultCode, resultAfterTranslation.ResultCode);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         [Fact(DisplayName = "Not translate because status code 401")]
//         public async Task NotTranslateBecauseStatusCode401()
//         {
//             httpContextMock.Response.StatusCode = 401;

//             nextMiddlewareInPipelineDelegateMock.Setup(it => it.Invoke(It.IsAny<HttpContext>()))
//                 .Callback(() => WriteObjectAsJsonInStream(httpContextMock.Response.Body, null));

//             await translationMiddleware.Invoke(httpContextMock);

//             nextMiddlewareInPipelineDelegateMock.Verify(it => it.Invoke(It.IsAny<HttpContext>()), Times.Once);
//             httpClientFactoryMock.Verify(it => it.CreateClient(It.IsAny<string>()), Times.Never);

//             Result resultAfterTranslation = ExtractResultFromResponseBody<Result>();

//             Assert.Null(resultAfterTranslation);
//             Assert.Null(memoryCache.Get($"{nameof(TranslationMiddleware)}_pt-BR_{Constant.Success}"));
//         }

//         private T ExtractResultFromResponseBody<T>()
//             where T : Result
//         {
//             httpContextMock.Response.Body.Seek(0, SeekOrigin.Begin);
//             var reader = new StreamReader(httpContextMock.Response.Body);
//             string streamText = reader.ReadToEnd();
//             T resultAfterTranslation = JsonConvert.DeserializeObject<T>(streamText);

//             if (resultAfterTranslation != null)
//                 UpdateResultStatusFromHttpResponse(resultAfterTranslation, httpContextMock.Response);

//             return resultAfterTranslation;
//         }

//         private void WriteObjectAsJsonInStream(Stream stream, object obj)
//         {
//             using (var streamWriter = new StreamWriter(stream: stream, encoding: Encoding.UTF8, bufferSize: 4096, leaveOpen: true))
//             {
//                 using (var jsonWriter = new JsonTextWriter(streamWriter))
//                 {
//                     var serializer = new JsonSerializer();
//                     serializer.Serialize(jsonWriter, obj);
//                     streamWriter.Flush();
//                     stream.Seek(0, SeekOrigin.Begin);
//                 }
//             }
//         }

//         private void UpdateResultStatusFromHttpResponse(Result result, HttpResponse httpResponse)
//         {
//             if (result.Message != Constant.Success)
//             {
//                 result.Set((ResultCode)(httpResponse.StatusCode), result.Message, result.Validations);
//                 return;
//             }

//             switch (httpResponse.StatusCode)
//             {
//                 case (int)HttpStatusCode.OK:
//                     result.Set(ResultCode.Ok, Constant.Success);
//                     break;

//                 case (int)HttpStatusCode.Created:
//                     result.Set((ResultCode)((int)HttpStatusCode.Created), "Created");
//                     break;

//                 case (int)HttpStatusCode.RequestTimeout:
//                     result.Set((ResultCode)((int)HttpStatusCode.RequestTimeout), "Request timeout");
//                     break;

//                 case (int)HttpStatusCode.GatewayTimeout:
//                     result.Set((ResultCode)((int)HttpStatusCode.GatewayTimeout), "Gateway timeout");
//                     break;

//                 case (int)HttpStatusCode.Accepted:
//                     result.Set((ResultCode)((int)HttpStatusCode.Accepted), "Accepted");
//                     break;

//                 case (int)HttpStatusCode.NotAcceptable:
//                     result.Set((ResultCode)((int)HttpStatusCode.NotAcceptable), "Not Acceptable");
//                     break;

//                 case (int)HttpStatusCode.BadRequest:
//                     if (!string.IsNullOrWhiteSpace(result.Message) && result.Message != Constant.Success)
//                         result.Set((ResultCode)((int)HttpStatusCode.BadRequest), result.Message.Replace("Validation - ", ""));
//                     else
//                         result.Set((ResultCode)((int)HttpStatusCode.BadRequest), "Bad request");
//                     break;

//                 case (int)HttpStatusCode.Forbidden:
//                     result.Set((ResultCode)((int)HttpStatusCode.Forbidden), "Forbidden");
//                     break;

//                 case (int)HttpStatusCode.InternalServerError:
//                     result.Set((ResultCode)((int)HttpStatusCode.InternalServerError), "Internal Server Error");
//                     break;

//                 case (int)HttpStatusCode.NotFound:
//                     result.Set((ResultCode)((int)HttpStatusCode.NotFound), "Not Found");
//                     break;

//                 case (int)HttpStatusCode.ServiceUnavailable:
//                     result.Set((ResultCode)((int)HttpStatusCode.ServiceUnavailable), "Service Unavailable");
//                     break;

//                 case (int)HttpStatusCode.Unauthorized:
//                     result.Set((ResultCode)((int)HttpStatusCode.Unauthorized), "Unauthorized");
//                     break;

//                 case (int)HttpStatusCode.MethodNotAllowed:
//                     result.Set((ResultCode)((int)HttpStatusCode.MethodNotAllowed), "MethodNotAllowed in subsequent HTTP request.");
//                     break;

//                 case 422:
//                     if (!string.IsNullOrWhiteSpace(result.Message) && result.Message != Constant.Success)
//                         result.Set((ResultCode)422, result.Message.Replace("Validation - ", ""));
//                     else
//                         result.Set((ResultCode)422, null);
//                     break;

//                 default:
//                     if (httpResponse.StatusCode > 400)
//                         result.Set((ResultCode)(httpResponse.StatusCode), $"Error returned in HttpClient call.");
//                     else
//                         result.Set((ResultCode)(httpResponse.StatusCode), result.Message ?? Constant.Success);
//                     break;
//             }
//         }

//         public class TestViewModel
//         {
//             public int Prop1 { get; set; }
//             public string Prop2 { get; set; }
//             public DateTime Prop3 { get; set; }
//         }
//     }
// }