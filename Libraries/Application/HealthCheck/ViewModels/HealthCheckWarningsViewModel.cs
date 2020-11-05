using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckWarningsViewModel
    {
        [DataContract] public enum SeverityEnum {[EnumMember] Critical = 1, [EnumMember] High, [EnumMember] Medium, [EnumMember] Low }

        [DataMember] public SeverityEnum SeverityLevel { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public bool ShouldNotify { get; set; }
    }
}