using System;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    [DataContract]
    public class HealthCheckLocalLogFileViewModel
    {
        [DataMember] public DateTime CreateDate { get; set; }
        [DataMember] public string Content { get; set; }
    }
}