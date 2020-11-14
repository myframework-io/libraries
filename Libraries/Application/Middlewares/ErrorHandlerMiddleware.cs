using Myframework.Libraries.Application.Extensions;
using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.Log.Contracts;
using Myframework.Libraries.Infra.Log.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myframework.Libraries.Application.Middlewares
{
    /// <summary>
    /// Middleware responsável por capturar erros não tratados, logar e gerar uma resposta padrão de erro.
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate nextMiddlewareInPipelineDelegate;
        private readonly LogOptions logOptions;
        private readonly IHttpContextAccessor accessor;
        private readonly ILogger<ErrorHandlerMiddleware> logger;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="nextMiddlewareInPipelineDelegate"></param>
        /// <param name="logOptions"></param>
        /// <param name="accessor"></param>
        /// <param name="logger"></param>
        public ErrorHandlerMiddleware(RequestDelegate nextMiddlewareInPipelineDelegate, IOptions<LogOptions> logOptions, IHttpContextAccessor accessor, ILogger<ErrorHandlerMiddleware> logger)
        {
            this.nextMiddlewareInPipelineDelegate = nextMiddlewareInPipelineDelegate;
            this.logOptions = logOptions.Value;
            this.accessor = accessor;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await nextMiddlewareInPipelineDelegate(context);
            }
            catch (Exception exc)
            {
                await HandleExceptionAsync(context, exc);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exc)
        {
            if (exc is AggregateException)
                exc = exc.InnerException;

            logger.LogError(exc.ToString());

            string errorMsg = logOptions.ShowErrorDetailsInResponse ? exc.ToString() : Constant.DefaultErrorMsg;

            StringValues stringValues = context.Request.Headers[Constant.Protocol];
            Guid protocol;

            if (stringValues != StringValues.Empty && stringValues.Any())
                Guid.TryParse(stringValues.FirstOrDefault(), out protocol);
            else
            {
                protocol = Guid.NewGuid();
                context.Request.Headers.Add(Constant.Protocol, protocol.ToString());
            }

            if (logOptions.EnableLogError)
            {
                IErrorLogger customErrorLogger = context.RequestServices.GetService<IErrorLogger>();

                try
                {
                    if (customErrorLogger == null)
                    {
                        if (!string.IsNullOrWhiteSpace(logOptions.DirectoryToLogErrorsOnFail))
                        {
                            if (!Directory.Exists(logOptions.DirectoryToLogErrorsOnFail))
                                Directory.CreateDirectory(logOptions.DirectoryToLogErrorsOnFail);

                            File.AppendAllText(Path.Combine(logOptions.DirectoryToLogErrorsOnFail, $"LogError-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt"), exc.ToString());
                        }
                    }
                    else
                    {
                        string loggedUser = context?.User?.Identity?.Name;
                        string ipCliente = accessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                        string requestUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request);

                        if (logOptions.LogErrorInBackground)
                            customErrorLogger.LogAsync(exc, protocol, loggedUser, ipCliente, requestUrl, context.Request.Method, context);
                        else
                        {
                            Result resultLog = await customErrorLogger.LogAsync(exc, protocol, loggedUser, ipCliente, requestUrl, context.Request.Method, context);

                            if (!resultLog.Valid && !string.IsNullOrWhiteSpace(logOptions.DirectoryToLogErrorsOnFail))
                                LogFailInFile(exc, JsonConvert.SerializeObject(resultLog, Formatting.Indented));
                        }
                    }
                }
                catch (Exception logExc)
                {
                    if (!string.IsNullOrWhiteSpace(logOptions.DirectoryToLogErrorsOnFail))
                        LogFailInFile(exc, logExc.ToString());

                    if (!logOptions.IgnoreExceptionsOccuredInLogProcess)
                        throw;
                }
            }

            if (string.IsNullOrWhiteSpace(logOptions.RedirectToPageIfIsNotAjaxRequest))
            {
                var result = new Result { Protocol = protocol };
                result.Set(ResultCode.GenericError, errorMsg);

                string resultJson = JsonConvert.SerializeObject(result);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)result.ResultCode;
                await context.Response.WriteAsync(resultJson);
            }
            else
            {
                if (context.Request.IsAjaxRequest())
                {
                    var result = new Result { Protocol = protocol };
                    result.Set(ResultCode.GenericError, errorMsg);

                    string resultJson = JsonConvert.SerializeObject(result);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)result.ResultCode;
                    await context.Response.WriteAsync(resultJson);
                }
                else
                    context.Response.Redirect(logOptions.RedirectToPageIfIsNotAjaxRequest, true);
            }
        }

        private void LogFailInFile(Exception exc, string errorOnLogging)
        {
            try
            {
                if (!Directory.Exists(logOptions.DirectoryToLogErrorsOnFail))
                    Directory.CreateDirectory(logOptions.DirectoryToLogErrorsOnFail);

                var sb = new StringBuilder();
                sb.AppendLine("##################################################");
                sb.AppendLine("# Fail to log the following exception:");
                sb.AppendLine("##################################################");
                sb.AppendLine($"- Type: {exc.GetType().Name}");
                sb.AppendLine($"- Message: {exc.Message}");
                sb.AppendLine($"- StackTrace: {exc.StackTrace}");

                Exception innerExc = exc.InnerException;

                while (innerExc != null)
                {
                    sb.AppendLine("");
                    sb.AppendLine("Inner exception:");
                    sb.AppendLine($"- Type: {innerExc.GetType().Name}");
                    sb.AppendLine($"- Message: {innerExc.Message}");
                    sb.AppendLine($"- StackTrace: {innerExc.StackTrace}");

                    innerExc = innerExc.InnerException;
                }

                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine("##################################################");
                sb.AppendLine("# Error ocurred trying log:");
                sb.AppendLine("##################################################");
                sb.AppendLine(errorOnLogging);

                File.AppendAllText(Path.Combine(logOptions.DirectoryToLogErrorsOnFail, $"FailOnLogError-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt"), sb.ToString());
            }
            catch
            {
                if (!logOptions.IgnoreExceptionsOccuredInLogFileProcess)
                    throw;
            }
        }
    }
}