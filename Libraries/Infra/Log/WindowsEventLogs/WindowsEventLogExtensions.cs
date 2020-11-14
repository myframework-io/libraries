using System;
using System.Diagnostics;

namespace Myframework.Libraries.Infra.Log.WindowsEventLogs
{
    /// <summary>
    /// Extensões para tratar o EventLog.
    /// </summary>
    public static class WindowsEventLogExtensions
    {
        /// <summary>
        /// Escreve no EventLog um erro ocorrido no Program.cs.
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="applicationName"></param>
        /// <param name="sourceName"></param>
        /// <param name="exc"></param> 
        /// <param name="logName"></param>
        public static void WriteEntryForAspNetCoreProgramException(this EventLog eventLog, string applicationName, string sourceName, Exception exc, string logName = "Application") =>
            eventLog.WriteEntryForClassException(applicationName, "Program.cs", sourceName, exc, 1, logName);

        /// <summary>
        /// Escreve no EventLog um erro ocorrido no Startup.cs, no método ConfigureServices.
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="applicationName"></param>
        /// <param name="sourceName"></param>
        /// <param name="exc"></param>
        /// <param name="logName"></param>
        public static void WriteEntryForAspNetCoreStartupConfigureServicesException(this EventLog eventLog, string applicationName, string sourceName, Exception exc, string logName = "Application") =>
            eventLog.WriteEntryForClassException(applicationName, "Startup.cs (ConfigureServices)", sourceName, exc, 2, logName);

        /// <summary>
        /// Escreve no EventLog um erro ocorrido no Startup.cs, no método Configure.
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="applicationName"></param>
        /// <param name="sourceName"></param>
        /// <param name="exc"></param>
        /// <param name="logName"></param>
        public static void WriteEntryForAspNetCoreStartupConfigureException(this EventLog eventLog, string applicationName, string sourceName, Exception exc, string logName = "Application") =>
            eventLog.WriteEntryForClassException(applicationName, "Startup.cs (Configure)", sourceName, exc, 3, logName);

        /// <summary>
        /// Escreve no EventLog um erro ocorrido em uma classe/arquivo.
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="applicationName"></param>
        /// <param name="className"></param>
        /// <param name="sourceName"></param>
        /// <param name="exc"></param>
        /// <param name="eventId"></param>
        /// <param name="logName"></param>
        public static void WriteEntryForClassException(this EventLog eventLog, string applicationName, string className, string sourceName, Exception exc, int eventId, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName))
                EventLog.CreateEventSource(sourceName, logName);

            eventLog.Log = logName;
            eventLog.Source = sourceName;
            eventLog.WriteEntry($@"
                - Application: {applicationName}
                - Class: {className}
                - Error type: {exc.GetType().Name}
                - StackTrace: " + exc.ToString(), EventLogEntryType.Error, eventId);
        }
    }
}