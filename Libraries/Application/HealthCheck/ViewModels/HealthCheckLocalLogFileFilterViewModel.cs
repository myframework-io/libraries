using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckLocalLogFileFilterViewModel
    {
        [DataMember] public int Page { get; set; }
        [DataMember] public int ItensPerPage { get; set; }
    }
}