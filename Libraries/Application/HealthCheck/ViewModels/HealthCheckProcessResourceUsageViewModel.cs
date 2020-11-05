using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckProcessResourceUsageViewModel
    {
        [DataMember] public double WorkingSet64Mb { get; set; }
        [DataMember] public double VirtualMemorySize64Mb { get; set; }
        [DataMember] public double PrivateMemorySize64Mb { get; set; }
    }
}