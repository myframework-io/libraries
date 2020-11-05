using System;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckDependenceViewModel
    {
        [DataMember] public int? HttpStatusCode { get; set; }
        [DataMember] public bool Reachable { get; set; } = true;
        [DataMember] public string ApiName { get; set; }
        [DataMember] public string ApiUrl { get; set; }
        [DataMember] public string Enviroment { get; set; }
        [DataMember] public HealthCheckDatabaseStatus DatabaseStatus { get; set; }
        [DataMember] public HealthCheckLocalLogFilesViewModel LocalLogFilesStatus { get; set; }
        [DataMember] public DateTime ServerDate { get; set; }
        [DataMember] public DateTime ServerDateUtc { get; set; }
        [DataMember] public string Details { get; set; }
        [DataMember] public TimeSpan? ResponseTime { get; set; }
    }
}