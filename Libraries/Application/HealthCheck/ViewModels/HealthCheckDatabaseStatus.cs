using System;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckDatabaseStatus
    {
        [DataMember] public bool Available { get; set; }
        [DataMember] public TimeSpan OpenCloseConnectionTime { get; set; }
    }
}