using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckViewModel
    {
        [DataMember] public string CurrentCulture { get; set; }
        [DataMember] public string ApiName { get; set; }
        [DataMember] public string Enviroment { get; set; }
        [DataMember] public DateTime ServerDate { get; set; }
        [DataMember] public DateTime ServerDateUtc { get; set; }
        [DataMember] public HealthCheckDatabaseStatus DatabaseStatus { get; set; }
        [DataMember] public HealthCheckLocalLogFilesViewModel LocalLogFilesStatus { get; set; }
        [DataMember] public List<HealthCheckDependenceViewModel> Dependences { get; set; }
        [DataMember] public List<HealthCheckWarningsViewModel> Warnings { get; set; }
        [DataMember] public HealthCheckProcessResourceUsageViewModel ResourcesUsage { get; set; }
    }
}