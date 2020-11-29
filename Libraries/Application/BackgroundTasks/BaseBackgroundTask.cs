using Myframework.Libraries.Application.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Myframework.Libraries.Application.BackgroundTasks
{
    /// <summary>
    /// Classe base com implementações comuns a execução de background taks.
    /// </summary>
    /// <typeparam name="TLogType"></typeparam>
    public abstract class BaseBackgroundTask : BackgroundService, IBackgroundTask
    {
        /// <summary>
        /// Classe que permite logar informações.
        /// </summary>
        protected readonly ILogger logger;
        private readonly BaseBackgroundTaskOptions taskOptions;
        private readonly BackgroundTaskGlobalOptions globalOptions;
        private readonly string className;

        public BackgroundTaskStatistic Statistic { get; private set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="taskOptions">Herde seu option de BaseBackgroundTaskOptions e passe via construtor.</param>
        /// <param name="logger">Logger para logar a execução da task.</param>
        public BaseBackgroundTask(BackgroundTaskGlobalOptions globalOptions, BaseBackgroundTaskOptions taskOptions, ILogger logger)
        {
            this.taskOptions = taskOptions ?? throw new ArgumentException("Options missing.", nameof(taskOptions));
            this.logger = logger ?? throw new ArgumentException("Logger missing.", nameof(logger));
            this.globalOptions = globalOptions ?? throw new ArgumentException("BackgroundTaskGlobalOptions missing.", nameof(globalOptions));

            className = GetType().Name;
            Statistic = new BackgroundTaskStatistic { Name = className };
        }

        /// <summary>
        /// Inicia a execução da task em background.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var sw = new Stopwatch();
            Statistic.StartDate = DateTime.Now;

            logger.LogDebug($"{className} is starting with configuration: .");

            stoppingToken.Register(() => logger.LogDebug($"#1 {className} background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                //TODO: reler o appsettings ou usar o IOptions q enxerga mudancas
                if (!taskOptions.Enabled || globalOptions.DisableAllBackgroundServices)
                {
                    await Task.Delay(10000, stoppingToken);
                    continue;
                }

                Statistic.Enabled = taskOptions.Enabled;
                Statistic.TimerInterval = taskOptions.Interval;

                sw.Restart();

                try
                {
                    Task task = DoTaskAsync();

                    if (taskOptions.AwaitTaskEndsToDelayInterval)
                        await task;
                }
                catch (Exception exc)
                {
                    logger.LogDebug($"{className} error: {exc.Message}.");
                    Statistic.AddError();
                }
                finally
                {
                    sw.Stop();

                    Statistic.LastRuntime = DateTime.Now;
                    Statistic.UpdateRun(sw.ElapsedMilliseconds);

                    await Task.Delay(taskOptions.Interval, stoppingToken);
                }
            }

            logger.LogDebug($"{className} background task is stopping.");

            await Task.CompletedTask;
        }

        /// <summary>
        /// Task que será executada pelo job.
        /// Atenção: Esse método será chamado periodicamente (valor do intervalo indicado na option), mesmo que a chamada anterior não termine.
        /// </summary>
        protected abstract Task DoTaskAsync();
    }
}