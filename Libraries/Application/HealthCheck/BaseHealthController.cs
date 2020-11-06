// using Myframework.Libraries.Application.BackgroundTasks;
// using Myframework.Libraries.Application.Base;
// using Myframework.Libraries.Application.HealthCheck.ViewModels;
// using Myframework.Libraries.Common.Constants;
// using Myframework.Libraries.Common.Pagination;
// using Myframework.Libraries.Common.Results;
// using Myframework.Libraries.Infra.Log.Options;
// using Microsoft.AspNetCore.Localization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Data.SqlClient;
// using Microsoft.Extensions.Caching.Memory;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Options;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Text;
// using System.Threading.Tasks;

// namespace Myframework.Libraries.Application.HealthCheck
// {
//     /// <summary>
//     /// Controller base para health check.
//     /// </summary>
//     public abstract class BaseHealthController : BaseController
//     {
//         protected readonly string connectionString;
//         protected readonly LogOptions logOptions;
//         protected readonly HealthCheckOptions healthCheckOptions;
//         protected readonly IMemoryCache memoryCache;

//         /// <summary>
//         /// 
//         /// </summary>
//         /// <param name="logOptions"></param>
//         /// <param name="healthCheckOptions"></param>
//         /// <param name="memoryCache"></param>
//         /// <param name="connectionString"></param>
//         public BaseHealthController(IOptions<LogOptions> logOptions, IOptions<HealthCheckOptions> healthCheckOptions, IMemoryCache memoryCache, string connectionString)
//         {
//             this.memoryCache = memoryCache ?? throw new ArgumentException("IMemoryCache cannot be null.");
//             this.connectionString = connectionString;
//             this.logOptions = logOptions.Value;
//             this.healthCheckOptions = healthCheckOptions.Value;
//         }

//         /// <summary>
//         /// Retorna o HealthCheck da API.
//         /// </summary>
//         /// <param name="serviceProvider"></param>
//         /// <param name="loadDependences"></param>
//         /// <returns></returns>
//         [HttpGet, Route("checks")]
//         public async Task<IActionResult> HealthCheckAsync([FromServices] IServiceProvider serviceProvider, bool loadDependences = true)
//         {
//             IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
//             System.Globalization.CultureInfo culture = rqf.RequestCulture.Culture;

//             return GetIActionResult(
//                 new Result<HealthCheckViewModel>
//                 {
//                     Value =
//                      new HealthCheckViewModel
//                      {
//                          CurrentCulture = culture.Name,
//                          ApiName = healthCheckOptions.ApiName,
//                          ServerDate = DateTime.Now,
//                          ServerDateUtc = DateTime.UtcNow,
//                          DatabaseStatus = GetDatabaseStatus(),
//                          LocalLogFilesStatus = CheckLocalLogFileWritePermission(),
//                          Enviroment = GetEnvironmentVariable(),
//                          Dependences = loadDependences ? await GetDependencesCheckListAsync() : new List<HealthCheckDependenceViewModel>(),
//                          Warnings = await GetWarningsAsync(),
//                          ResourcesUsage = GetProcessResourceUsage(serviceProvider)
//                      }
//                 });
//         }

//         /// <summary>
//         /// Retorna HttpStatusCode.OK. Serve para checar se a API está acessível.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("checks/up")]
//         public IActionResult ApiUp() =>
//             GetIActionResult(new Result());

//         /// <summary>
//         /// Retorna HttpStatusCode.OK quando a API tem acesso de escrita na pasta local de logs e retorna HttpStatusCode.UnprocessableEntity quando não tiver.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("checks/logs/local")]
//         public IActionResult CheckLocalLogDirectoryAsync() =>
//             GetIActionResult(new Result<HealthCheckLocalLogFilesViewModel> { Value = CheckLocalLogFileWritePermission() });

//         /// <summary>
//         /// Limpa o repositório local de logs.
//         /// </summary>
//         /// <returns></returns>
//         [HttpDelete, Route("logs/local")]
//         public IActionResult ClearLocalLogDirectory()
//         {
//             var dir = new System.IO.DirectoryInfo(logOptions.DirectoryToLogErrorsOnFail);

//             foreach (System.IO.FileInfo file in dir.GetFiles())
//             {
//                 file.Delete();
//             }

//             return GetIActionResult(new Result());
//         }

//         /// <summary>
//         /// Retorna a lista dos últimos arquivos gerados.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("logs/local")]
//         public IActionResult GetLocalLogsAsync([FromQuery] HealthCheckLocalLogFileFilterViewModel filter)
//         {
//             if (filter == null)
//                 filter = new HealthCheckLocalLogFileFilterViewModel { Page = 0, ItensPerPage = 10 };

//             if (filter.ItensPerPage < 1 || filter.ItensPerPage > 10)
//                 filter.ItensPerPage = 10;

//             if (filter.Page < 0)
//                 filter.Page = 0;

//             var dir = new System.IO.DirectoryInfo(logOptions.DirectoryToLogErrorsOnFail);

//             if (!dir.Exists)
//                 return GetIActionResult(new Result().SetBusinessMessage("Log directory not found."));

//             System.IO.FileInfo[] files = dir.GetFiles();

//             if (files == null || files.Length == 0)
//                 return GetIActionResult(new Result<PagedList<HealthCheckLocalLogFileViewModel>> { Value = new PagedList<HealthCheckLocalLogFileViewModel>(new List<HealthCheckLocalLogFileViewModel>(), filter.Page, 0, filter.ItensPerPage) });

//             var pagging = new PaggingCalculation(filter.Page, files.Length, filter.ItensPerPage);

//             var result = new Result<PagedList<HealthCheckLocalLogFileViewModel>>
//             {
//                 Value = new PagedList<HealthCheckLocalLogFileViewModel>(new List<HealthCheckLocalLogFileViewModel>(), pagging.Page, pagging.TotalItens, pagging.ItensPerPage)
//             };

//             var filesPaged = files.Skip(pagging.Page * pagging.ItensPerPage).Take(pagging.ItensPerPage).ToList();

//             foreach (System.IO.FileInfo file in filesPaged)
//             {
//                 result.Value.Itens.Add(
//                     new HealthCheckLocalLogFileViewModel
//                     {
//                         CreateDate = file.CreationTime,
//                         Content = System.IO.File.ReadAllText(file.FullName)
//                     });
//             }

//             return GetIActionResult(result);
//         }

//         /// <summary>
//         /// Retorna detalhes sobre a conexão da API com o banco de dados.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("checks/databases/connections")]
//         public IActionResult CheckDatabaseConnection() =>
//             GetIActionResult(new Result<HealthCheckDatabaseStatus> { Value = GetDatabaseStatus() });

//         /// <summary>
//         /// Retorna a variável de ambiente do ASP.NET CORE.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("checks/environments/variables")]
//         public IActionResult GetEnvironmentVariableAction() =>
//             GetIActionResult(new Result<string> { Value = GetEnvironmentVariable() });

//         /// <summary>
//         /// Obtém estatística de uso de recursos da API.
//         /// </summary>
//         /// <returns></returns>
//         [HttpPost, Route("checks/process"), ApiExplorerSettings(IgnoreApi = true)]
//         public IActionResult GetProcessResourceUsageActionAsync([FromServices] IServiceProvider serviceProvider) =>
//             GetIActionResult(new Result<HealthCheckProcessResourceUsageViewModel> { Value = GetProcessResourceUsage(serviceProvider) });

//         /// <summary>
//         /// Gera arquivo local de erro.
//         /// </summary>
//         /// <returns></returns>
//         [HttpPost, Route("logs/local/errors"), ApiExplorerSettings(IgnoreApi = true)]
//         public IActionResult GenerateErrorLogLocal() =>
//             GetIActionResult(new Result<string> { Value = GenerateLocalErrorFile() });

//         /// <summary>
//         /// Lança uma exceção para ser tratada pelo middleware de erros.
//         /// </summary>
//         /// <returns></returns>
//         [HttpPost, Route("exceptions"), ApiExplorerSettings(IgnoreApi = true)]
//         public IActionResult GenerateExceptionForMiddleware() =>
//             throw new Exception("Exception simulation in HealthCheck. Check file in log directory.", new Exception("Inner Exception simulation in HealthCheck."));

//         /// <summary>
//         /// Retorna a statísticas de execução de jobs.
//         /// </summary>
//         /// <param name="services"></param>
//         /// <returns></returns>
//         [HttpGet, Route("backgroundtasks")]
//         public IActionResult GetBackgroundTasksStatisticsHealth([FromServices] IEnumerable<IHostedService> services) =>
//             GetIActionResult(new Result<List<HealthCheckBackgroundTaskViewModel>> { Value = GetBackgroundTasksStatistics(services) });

//         /// <summary>
//         /// Recebe informações usando [FromQuery] e retorna exatamente o que foi deserializado, para que possa comparar o que foi enviado para o servidor e como o sevidor entendeu.
//         /// </summary>
//         /// <param name="obj"></param>
//         /// <returns></returns>
//         [HttpGet, Route("checks/serialization/get")]
//         public IActionResult CheckSerializationAndDeserializationForHttpGet([FromQuery] HealthCheckSerializationAndDeserializationViewModel obj)
//         {
//             obj = obj ?? new HealthCheckSerializationAndDeserializationViewModel();

//             IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
//             System.Globalization.CultureInfo culture = rqf.RequestCulture.Culture;

//             return Ok(new { Culture = culture.Name, FromQuery = obj });
//         }

//         /// <summary>
//         /// Recebe informações usando [FromBody] e retorna exatamente o que foi deserializado, para que possa comparar o que foi enviado para o servidor e como o sevidor entendeu.
//         /// </summary>
//         /// <param name="obj"></param>
//         /// <returns></returns>
//         [HttpPost, Route("checks/serialization/post")]
//         public IActionResult CheckSerializationAndDeserializationForHttpPost([FromBody] HealthCheckSerializationAndDeserializationViewModel obj)
//         {
//             obj = obj ?? new HealthCheckSerializationAndDeserializationViewModel();

//             IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
//             System.Globalization.CultureInfo culture = rqf.RequestCulture.Culture;

//             return Ok(new { Culture = culture.Name, FromBody = obj });
//         }

//         /// <summary>
//         /// Recebe informações usando [FromRoute] e [FromBody] e retorna exatamente o que foi deserializado, para que possa comparar o que foi enviado para o servidor e como o sevidor entendeu.
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="obj"></param>
//         /// <returns></returns>
//         [HttpPut, Route("checks/serialization/put/{id}")]
//         public IActionResult CheckSerializationAndDeserializationForHttpPut([FromRoute] int id, [FromBody] HealthCheckSerializationAndDeserializationViewModel obj)
//         {
//             obj = obj ?? new HealthCheckSerializationAndDeserializationViewModel();

//             IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
//             System.Globalization.CultureInfo culture = rqf.RequestCulture.Culture;

//             return Ok(new { Culture = culture.Name, FromRoute = id, FromBody = obj });
//         }

//         /// <summary>
//         /// Gera um Result do tipo BusinessError para validar a tradução do globalization.
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet, Route("checks/globalization/business-error")]
//         public IActionResult CheckGlobalizationBusinessError()
//         {
//             var result = new Result();
//             result.AddValidation("Name", "Cannot be null.");
//             result.AddValidation("Age", "Cannot be empty.");

//             return GetIActionResult(result);
//         }

//         /// <summary>
//         /// Obtem warnings personalizados da API.
//         /// </summary>
//         /// <returns></returns>
//         protected virtual async Task<List<HealthCheckWarningsViewModel>> GetWarningsAsync() =>
//             await Task.FromResult(new List<HealthCheckWarningsViewModel>());

//         private async Task<List<HealthCheckDependenceViewModel>> GetDependencesCheckListAsync()
//         {
//             if (healthCheckOptions.DependencesResources == null || !healthCheckOptions.DependencesResources.Any())
//                 return new List<HealthCheckDependenceViewModel>();

//             return await memoryCache.GetOrCreateAsync("HealthCheck_Dependences", async entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = healthCheckOptions.TimeSpanToKeepHealthCheckCached;

//                 var tasks = new List<Task<HealthCheckDependenceViewModel>>();

//                 foreach (string depResUrl in healthCheckOptions.DependencesResources)
//                 {
//                     tasks.Add(CheckListDependenceAsync(depResUrl));
//                 }

//                 await Task.WhenAll(tasks);

//                 return tasks.Select(it => it.Result).ToList();
//             });
//         }

//         private async Task<HealthCheckDependenceViewModel> CheckListDependenceAsync(string url)
//         {
//             HealthCheckDependenceViewModel checkList;

//             string authToken = Request.Headers[Constant.Authorization].ToString();

//             if (authToken == null)
//                 throw new Exception("Authorization header missing.");

//             if (authToken.StartsWith("Bearer "))
//                 authToken = authToken.Substring(7);

//             using (var httpClient = new HttpClient { Timeout = healthCheckOptions.DependencesResourcesTimeOut })
//             {
//                 //httpClient.SetBearerToken(authToken);
//                 httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

//                 HttpResponseMessage httpResponse = null;

//                 var sw = Stopwatch.StartNew();

//                 if (!url.Contains("loadDependences=false"))
//                     throw new Exception("Attention! The HealthCheck requires parameter 'loadDependences = false' to prevent infinite loop on HealthChecks calls.");

//                 try
//                 {
//                     httpResponse = await httpClient.GetAsync(url);
//                 }
//                 catch (Exception exc)
//                 {
//                     checkList = new HealthCheckDependenceViewModel
//                     {
//                         HttpStatusCode = null,
//                         ApiName = null,
//                         ApiUrl = url,
//                         DatabaseStatus = null,
//                         Enviroment = null,
//                         LocalLogFilesStatus = null,
//                         Reachable = false,
//                         ResponseTime = null,
//                         Details = $"Error on HttpClient call: {exc.ToString()}"
//                     };

//                     return checkList;
//                 }
//                 finally
//                 {
//                     sw.Stop();
//                 }

//                 string json = "";
//                 if (httpResponse.IsSuccessStatusCode)
//                 {
//                     try
//                     {
//                         json = await httpResponse.Content.ReadAsStringAsync();

//                         Result<HealthCheckDependenceViewModel> checkListResult = JsonConvert.DeserializeObject<Result<HealthCheckDependenceViewModel>>(json,
//                             new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

//                         checkList = checkListResult.Value;

//                         checkList.ApiUrl = url;
//                         checkList.Reachable = true;
//                         checkList.HttpStatusCode = (int)httpResponse.StatusCode;
//                         checkList.ResponseTime = sw.Elapsed;
//                     }
//                     catch (Exception)
//                     {
//                         checkList = new HealthCheckDependenceViewModel
//                         {
//                             HttpStatusCode = (int)httpResponse.StatusCode,
//                             ApiName = null,
//                             ApiUrl = url,
//                             DatabaseStatus = null,
//                             Enviroment = null,
//                             LocalLogFilesStatus = null,
//                             Reachable = true,
//                             Details = "Error on deserialize json.",
//                             ResponseTime = sw.Elapsed
//                         };

//                         return checkList;
//                     }
//                 }
//                 else
//                 {
//                     checkList =
//                         new HealthCheckDependenceViewModel
//                         {
//                             HttpStatusCode = (int)httpResponse.StatusCode,
//                             ApiName = null,
//                             ApiUrl = url,
//                             DatabaseStatus = null,
//                             Enviroment = null,
//                             LocalLogFilesStatus = null,
//                             Reachable = false,
//                             ResponseTime = sw.Elapsed
//                         };

//                     return checkList;
//                 }

//                 return checkList;
//             }
//         }

//         private HealthCheckLocalLogFilesViewModel CheckLocalLogFileWritePermission()
//         {
//             return memoryCache.GetOrCreate("HealthCheck_LocalLogFiles", entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = healthCheckOptions.TimeSpanToKeepHealthCheckCached;

//                 var health = new HealthCheckLocalLogFilesViewModel();

//                 try
//                 {
//                     GenerateLocalErrorFile(true);
//                     health.HasPermissionToWriteInDirectory = true;
//                 }
//                 catch
//                 {
//                     health.HasPermissionToWriteInDirectory = false;
//                 }

//                 if (health.HasPermissionToWriteInDirectory)
//                     health.FilesCount = System.IO.Directory.EnumerateFiles(logOptions.DirectoryToLogErrorsOnFail).Count();

//                 return health;
//             });
//         }

//         private HealthCheckDatabaseStatus GetDatabaseStatus()
//         {
//             return memoryCache.GetOrCreate("HealthCheck_DatabaseConnectionAvaible", entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = healthCheckOptions.TimeSpanToKeepHealthCheckCached;

//                 try
//                 {
//                     var stopwatch = Stopwatch.StartNew();
//                     using (var conn = new SqlConnection(connectionString)) { conn.Open(); }
//                     stopwatch.Stop();
//                     return new HealthCheckDatabaseStatus { Available = true, OpenCloseConnectionTime = stopwatch.Elapsed };
//                 }
//                 catch
//                 {
//                     return new HealthCheckDatabaseStatus { Available = false, OpenCloseConnectionTime = new TimeSpan() };
//                 }
//             });
//         }

//         private HealthCheckProcessResourceUsageViewModel GetProcessResourceUsage(IServiceProvider serviceProvider)
//         {
//             return memoryCache.GetOrCreate("HealthCheck_ProcessResourceUsage", entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = new TimeSpan(0, 0, 5);

//                 var process = Process.GetCurrentProcess();

//                 return new HealthCheckProcessResourceUsageViewModel
//                 {
//                     WorkingSet64Mb = process == null ? 0 : process.WorkingSet64 / (double)1024 / 1024,
//                     VirtualMemorySize64Mb = process == null ? 0 : process.VirtualMemorySize64 / (double)1024 / 1024,
//                     PrivateMemorySize64Mb = process == null ? 0 : process.PrivateMemorySize64 / (double)1024 / 1024,
//                 };
//             });
//         }

//         private string GetEnvironmentVariable()
//         {
//             return memoryCache.GetOrCreate("HealthCheck_Enviroment", entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = healthCheckOptions.TimeSpanToKeepHealthCheckCached;
//                 return Environment.GetEnvironmentVariable(Constant.AspNetCoreEnviromentVariable);
//             });
//         }

//         private string GenerateLocalErrorFile(bool eraseFileAfterCreate = false)
//         {
//             var exc = new Exception("Health check generate error for test purpose");

//             var sb = new StringBuilder();
//             sb.AppendLine("##################################################");
//             sb.AppendLine("# Fail to log the following exception:");
//             sb.AppendLine("##################################################");
//             sb.AppendLine($"- Type: {exc.GetType().Name}");
//             sb.AppendLine($"- Message: {exc.Message}");
//             sb.AppendLine($"- StackTrace: {exc.StackTrace}");

//             Exception innerExc = exc.InnerException;

//             while (innerExc != null)
//             {
//                 sb.AppendLine("");
//                 sb.AppendLine("Inner exception:");
//                 sb.AppendLine($"- Type: {innerExc.GetType().Name}");
//                 sb.AppendLine($"- Message: {innerExc.Message}");
//                 sb.AppendLine($"- StackTrace: {innerExc.StackTrace}");

//                 innerExc = innerExc.InnerException;
//             }

//             string fileName = $"FailOnLogError-{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.txt";
//             System.IO.File.AppendAllText(System.IO.Path.Combine(logOptions.DirectoryToLogErrorsOnFail, fileName), sb.ToString());

//             if (eraseFileAfterCreate)
//                 System.IO.File.Delete(System.IO.Path.Combine(logOptions.DirectoryToLogErrorsOnFail, fileName));

//             return fileName;
//         }

//         private List<HealthCheckBackgroundTaskViewModel> GetBackgroundTasksStatistics(IEnumerable<IHostedService> services)
//         {
//             return memoryCache.GetOrCreate("HealthCheck_BackgroundTasksStatistics", entry =>
//             {
//                 entry.AbsoluteExpirationRelativeToNow = new TimeSpan(0, 0, 5);

//                 if (services == null)
//                     return new List<HealthCheckBackgroundTaskViewModel>();

//                 var backTasksFramework = services.Where(it => it is BaseBackgroundTask).Select(it => (BaseBackgroundTask)it).ToList();

//                 return backTasksFramework.Select(it =>
//                     new HealthCheckBackgroundTaskViewModel
//                     {
//                         AverageRuntime = it.Statistic.AverageRuntime,
//                         BestRuntime = it.Statistic.BestRuntime,
//                         Enabled = it.Statistic.Enabled,
//                         ErrorsCount = it.Statistic.ErrorsCount,
//                         Name = it.Statistic.Name,
//                         RunCount = it.Statistic.RunCount,
//                         StartDate = it.Statistic.StartDate,
//                         TimerInterval = it.Statistic.TimerInterval,
//                         WorstRuntime = it.Statistic.WorstRuntime,
//                         LastRuntime = it.Statistic.LastRuntime
//                     }).ToList();
//             });
//         }
//     }
// }