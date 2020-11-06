// using Myframework.Libraries.Infra.Log.Contracts;
// using Myframework.Libraries.Infra.Log.Options;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Options;
// using System;
// using System.Diagnostics;
// using System.IO;
// using System.Threading.Tasks;

// namespace Myframework.Libraries.Application.Middlewares
// {
//     /// <summary>
//     /// Middleware responsável por logar request e response como um só registro.
//     /// </summary>
//     public class RequestResponseLoggingMiddleware
//     {
//         private readonly RequestDelegate nextMiddlewareInPipelineDelegate;
//         private readonly LogOptions logOptions;

//         /// <summary>
//         /// Construtor padrão.
//         /// </summary>
//         public RequestResponseLoggingMiddleware(RequestDelegate nextMiddlewareInPipelineDelegate, IOptions<LogOptions> logOptions)
//         {
//             this.nextMiddlewareInPipelineDelegate = nextMiddlewareInPipelineDelegate;
//             this.logOptions = logOptions.Value;
//         }

//         /// <summary>
//         /// 
//         /// </summary>
//         public async Task Invoke(HttpContext context)
//         {
//             if (logOptions.EnableLogRequest)
//                 await InvokeWithLog(context);
//             else
//                 await nextMiddlewareInPipelineDelegate(context);
//         }

//         private async Task InvokeWithLog(HttpContext context)
//         {
//             var watch = Stopwatch.StartNew();
//             DateTime requestTimestamp = DateTime.Now;

//             var requestBodyStream = new MemoryStream();
//             Stream originalRequestBody = context.Request.Body;

//             await context.Request.Body.CopyToAsync(requestBodyStream);
//             requestBodyStream.Seek(0, SeekOrigin.Begin);

//             string requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

//             requestBodyStream.Seek(0, SeekOrigin.Begin);
//             context.Request.Body = requestBodyStream;

//             Stream originalResponseBodyStream = context.Response.Body;
//             var responseBodyStream = new MemoryStream();
//             context.Response.Body = responseBodyStream;

//             await nextMiddlewareInPipelineDelegate(context);

//             context.Request.Body = originalRequestBody;

//             responseBodyStream.Seek(0, SeekOrigin.Begin);
//             string responseBodyText = new StreamReader(responseBodyStream).ReadToEnd();

//             IRequestResponseLogger logger = context.RequestServices.GetRequiredService<IRequestResponseLogger>();

//             watch.Stop();

//             try
//             {
//                 if (logger != null)
//                     await logger.Logar(context, requestTimestamp, requestTimestamp.Add(watch.Elapsed), requestBodyText, responseBodyText, watch.ElapsedMilliseconds);
//             }
//             catch (Exception exc)
//             {
//                 if (!logger.LogOptions.IgnoreExceptionsOccuredInLogProcess)
//                     throw exc;
//             }

//             responseBodyStream.Seek(0, SeekOrigin.Begin);
//             await responseBodyStream.CopyToAsync(originalResponseBodyStream);
//         }
//     }
// }