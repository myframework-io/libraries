using System;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckBackgroundTaskViewModel
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public DateTime StartDate { get; set; }
        [DataMember] public TimeSpan TimerInterval { get; set; }
        [DataMember] public long RunCount { get; set; }
        [DataMember] public long ErrorsCount { get; set; }
        [DataMember] public bool Enabled { get; set; }
        [DataMember] public TimeSpan? AverageRuntime { get; set; }
        [DataMember] public TimeSpan? BestRuntime { get; set; }
        [DataMember] public TimeSpan? WorstRuntime { get; set; }
        [DataMember] public DateTime? LastRuntime { get; set; }
    }
}