// using Myframework.Libraries.Application.Options;
// using Myframework.Libraries.Common.Constants;
// using Myframework.Libraries.Common.Results;
// using Myframework.Libraries.Infra.Log.Contracts;
// using Myframework.Libraries.Infra.Security;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Caching.Memory;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using Microsoft.IO;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
// using System;
// using System.IO;
// using System.Linq;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Runtime.ExceptionServices;
// using System.Text;
// using System.Threading.Tasks;

// namespace Myframework.Libraries.Application.Middlewares
// {
//     /// <summary>
//     /// Middleware responsável por traduzir o response da chamada HTTP baseada no Result.
//     /// </summary>
//     public class TranslationMiddleware
//     {
//         private readonly RequestDelegate nextMiddlewareInPipelineDelegate;
//         private readonly RecyclableMemoryStreamManager recyclableMemoryStreamManager;
//         private readonly IClientTokenManager tokenManager;
//         private readonly ILogger<TranslationMiddleware> logger;
//         private readonly IErrorLogger errorLogger;
//         private readonly IMemoryCache memoryCache;
//         private readonly IHttpClientFactory httpClientFactory;
//         private readonly TranslationOptions translateOptions;
//         private readonly GlobalizationOptions globalizationOptions;

//         /// <summary>
//         /// Construtor padrão
//         /// </summary>
//         /// <param name="nextMiddlewareInPipelineDelegate"></param>
//         /// <param name="tokenManager"></param>
//         /// <param name="logger"></param>
//         /// <param name="errorLogger"></param>
//         /// <param name="translateOptions"></param>
//         /// <param name="globalizationOptions"></param>
//         /// <param name="memoryCache"></param>
//         /// <param name="httpClientFactory"></param>
//         public TranslationMiddleware(RequestDelegate nextMiddlewareInPipelineDelegate, IClientTokenManager tokenManager, ILogger<TranslationMiddleware> logger, IErrorLogger errorLogger, IOptions<TranslationOptions> translateOptions, IOptions<GlobalizationOptions> globalizationOptions, IMemoryCache memoryCache, IHttpClientFactory httpClientFactory)
//         {
//             this.nextMiddlewareInPipelineDelegate = nextMiddlewareInPipelineDelegate;
//             this.tokenManager = tokenManager;
//             this.logger = logger;
//             this.errorLogger = errorLogger;
//             this.translateOptions = translateOptions?.Value ?? throw new ArgumentException("Translate options required.");
//             this.globalizationOptions = globalizationOptions?.Value ?? throw new ArgumentException("Globalization options required.");
//             this.memoryCache = memoryCache ?? throw new ArgumentException("IMemoryCache options required.");
//             this.httpClientFactory = httpClientFactory ?? throw new ArgumentException("IHttpClientFactory required.");
//             recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
//         }

//         public async Task Invoke(HttpContext context)
//         {
//             // Não rodar processo de tradução se estiver desabilitado ou o request atual contiver o header "TranslateRequest", que significa uma chamada feita no pipeline de tradução
//             if (!translateOptions.Enabled || context.Request.Headers.ContainsKey("TranslateRequest"))
//             {
//                 await nextMiddlewareInPipelineDelegate(context);
//                 return;
//             }

//             string headerAcceptLanguage = context.Request.Headers.ContainsKey("Accept-Language")
//                 ? context.Request.Headers["Accept-Language"].ToString()
//                 : null;

//             // Não rodar processo de tradução se não foi enviada uma linguagem específica no header ou se a linguagem for a mesma da config default
//             if (string.IsNullOrWhiteSpace(headerAcceptLanguage) || headerAcceptLanguage.ToLower() == (globalizationOptions.DefaultRequestCulture?.ToLower() ?? "en-us"))
//             {
//                 await nextMiddlewareInPipelineDelegate(context);
//                 return;
//             }

//             // Essa parte de cópia de stream é necessária para que o body do response possa ser lido múltiplas vezes (por middlewares e pela saída final da API)
//             Stream originalBodyStream = context.Response.Body;

//             await using MemoryStream responseBody = recyclableMemoryStreamManager.GetStream();
//             context.Response.Body = responseBody;

//             try
//             {
//                 await nextMiddlewareInPipelineDelegate(context);

//                 context.Response.Body.Seek(0, SeekOrigin.Begin);
//                 string responseBodyStr = await new StreamReader(context.Response.Body).ReadToEndAsync();
//                 context.Response.Body.Seek(0, SeekOrigin.Begin);

//                 // Traduzir somente quando não for 401, que dispensa tradução
//                 if (context.Response.StatusCode != 401)
//                     await TranslateAsync(context, responseBody, headerAcceptLanguage, responseBodyStr);

//                 await responseBody.CopyToAsync(originalBodyStream);
//             }
//             catch (Exception exc)
//             {                
//                 ExceptionDispatchInfo.Capture(exc).Throw();
//             }
//             finally
//             {
//                 context.Response.Body = originalBodyStream;
//             }
//         }

//         private async Task TranslateAsync(HttpContext context, MemoryStream responseBody, string headerAcceptLanguage, string responseBodyStr)
//         {
//             if (string.IsNullOrWhiteSpace(responseBodyStr))
//                 return;

//             Result resultResponse = GetResultFromBody(responseBodyStr);

//             if (resultResponse == null)
//                 return;

//             bool successResult = resultResponse.Message == Constant.Success && (resultResponse.Validations != null || !resultResponse.Validations.Any());
//             string successCacheKey = $"{nameof(TranslationMiddleware)}_{headerAcceptLanguage}_{Constant.Success}";

//             // Se for um result valido e sem validations, tentar recuperar do cache para evitar idas desnecessárias ao globalization
//             if (successResult && memoryCache.Get(successCacheKey) is string cacheSuccessMessage && !string.IsNullOrWhiteSpace(cacheSuccessMessage))
//             {
//                 TranslateSuccessMessageFromCache(context, responseBody, responseBodyStr, cacheSuccessMessage);
//                 return;
//             }

//             await TranslateFromGlobalizationApiAsync(context, responseBody, headerAcceptLanguage, resultResponse, responseBodyStr, successResult, successCacheKey);
//         }

//         private void TranslateSuccessMessageFromCache(HttpContext context, MemoryStream responseBody, string responseBodyStr, string cacheSuccessMessage)
//         {
//             Result resultTranslate = new Result().Set(ResultCode.Ok, cacheSuccessMessage);

//             var jObject = JObject.Parse(responseBodyStr);
//             UpdateJsonWithTranslateValues(resultTranslate, jObject);
//             string newResponseBodyStr = jObject.ToString();

//             RewriteReponse(context, responseBody, newResponseBodyStr);
//         }

//         private async Task TranslateFromGlobalizationApiAsync(HttpContext context, MemoryStream responseBody, string headerAcceptLanguage, Result resultResponse, string responseBodyStr, bool successResult, string successCacheKey)
//         {
//             Result<string> resultToken = await tokenManager.GetAccessTokenAsync();

//             if (!resultToken.Valid)
//             {
//                 string errorMsg = $"{nameof(TranslationMiddleware)}: Error on get token. Details: {resultToken.Message}";

//                 logger.LogCritical(errorMsg);
//                 await errorLogger.LogAsync(new Exception(errorMsg), Guid.NewGuid(), null, null, nameof(TranslationMiddleware), null);

//                 return;
//             }

//             string token = resultToken.Value;

//             try
//             {
//                 HttpClient httpClient = httpClientFactory.CreateClient();
//                 httpClient.BaseAddress = new Uri(translateOptions.BaseUrl);
//                 httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
//                 httpClient.DefaultRequestHeaders.Add("Accept-Language", headerAcceptLanguage);
//                 httpClient.DefaultRequestHeaders.Add("TranslateRequest", "true");
//                 httpClient.Timeout = translateOptions.ApiTimeout ?? new TimeSpan(0, 0, 5);

//                 string requestTranslate = JsonConvert.SerializeObject(new Result().SetFromAnother(resultResponse));

//                 HttpResponseMessage response = await httpClient.PostAsync(translateOptions.ResultTranslateRoute, new StringContent(requestTranslate, Encoding.UTF8, "application/json"));

//                 if (response != null && response.IsSuccessStatusCode)
//                 {
//                     string resultTranslateStr = await response.Content.ReadAsStringAsync();
//                     Result resultTranslate = JsonConvert.DeserializeObject<Result>(resultTranslateStr);

//                     var jObject = JObject.Parse(responseBodyStr);

//                     UpdateJsonWithTranslateValues(resultTranslate, jObject);

//                     string newResponseBodyStr = jObject.ToString();

//                     if (successResult)
//                     {
//                         using (ICacheEntry entryCache = memoryCache.CreateEntry(successCacheKey))
//                         {
//                             entryCache.Value = resultTranslate?.Message ?? resultResponse?.Message;
//                             entryCache.AbsoluteExpirationRelativeToNow = translateOptions.CacheTimeoutForSuccessResultTranslation;
//                         }
//                     }

//                     RewriteReponse(context, responseBody, newResponseBodyStr);
//                 }
//             }
//             catch (Exception exc)
//             {
//                 await TryLogErrorAsync(exc);

//                 if (translateOptions.ThrowExceptionWhenErrorOcurrInTranslate)
//                     throw new Exception("Error in translation middleware.", exc);
//             }
//         }

//         private void RewriteReponse(HttpContext context, MemoryStream responseBody, string newResponseBodyStr)
//         {
//             var sw = new StreamWriter(responseBody);
//             sw.Write(newResponseBodyStr);
//             sw.Flush();

//             responseBody.Seek(0, SeekOrigin.Begin);

//             context.Response.ContentLength = null;
//         }

//         private void UpdateJsonWithTranslateValues(Result resultTranslate, JObject jObject)
//         {
//             foreach (JProperty prop in jObject.Children().OfType<JProperty>())
//             {
//                 switch (prop.Name)
//                 {
//                     case "message":
//                         prop.Value = resultTranslate.Message;
//                         break;

//                     case "validations":
//                         if (resultTranslate.Validations != null && resultTranslate.Validations.Any())
//                         {
//                             int index = 0;

//                             foreach (JToken validation in prop.Children().Children())
//                             {
//                                 foreach (JProperty validationProp in validation.Children().OfType<JProperty>())
//                                 {
//                                     switch (validationProp.Name)
//                                     {
//                                         case "attribute":
//                                             validationProp.Value = resultTranslate.Validations[index].Attribute;
//                                             break;

//                                         case "message":
//                                             validationProp.Value = resultTranslate.Validations[index].Message;
//                                             break;
//                                     }
//                                 }

//                                 index++;
//                             }
//                         }
//                         break;
//                 }
//             }
//         }

//         private Result GetResultFromBody(string responseBodyStr)
//         {
//             if (string.IsNullOrWhiteSpace(responseBodyStr))
//                 return null;

//             try
//             {
//                 // Deserialiazndo o response para extrair message e validations e não enviar a prop "Response (Value)" para diminuir o trafego
//                 return JsonConvert.DeserializeObject<Result>(responseBodyStr);
//             }
//             catch
//             {
//                 // Não lançar erro se nao conseguir deserializar o result
//                 return null;
//             }
//         }

//         private async Task TryLogErrorAsync(Exception exc)
//         {
//             try
//             {
//                 string errorMsg = $"{nameof(TranslationMiddleware)}: {exc}";

//                 logger.LogCritical(errorMsg);
//                 await errorLogger.LogAsync(exc, Guid.NewGuid(), null, null, nameof(TranslationMiddleware), null);
//             }
//             catch (Exception exc2)
//             {
//                 if (translateOptions.ThrowExceptionWhenErrorOcurrInTranslate)
//                     throw new Exception("Error in translation middleware.", exc2);
//             }
//         }
//     }
// }