using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckLocalLogFilesViewModel
    {
        [DataMember] public bool HasPermissionToWriteInDirectory { get; set; }
        [DataMember] public int? FilesCount { get; set; }
    }
}