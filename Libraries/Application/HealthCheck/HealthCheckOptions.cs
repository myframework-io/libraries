using System;
using System.Collections.Generic;

namespace Myframework.Libraries.Application.HealthCheck
{
    public class HealthCheckOptions
    {
        public string ApiName { get; set; }
        public TimeSpan TimeSpanToKeepHealthCheckCached { get; set; }
        public TimeSpan DependencesResourcesTimeOut { get; set; }
        public List<string> DependencesResources { get; set; }
    }
}