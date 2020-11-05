using System;

namespace Myframework.Libraries.Infra.Http
{
    public class BaseHttpServiceOptions
    {
        public TimeSpan Timeout { get; set; }
        public string BaseUrl { get; set; }
        public int Retries { get; set; }
        public TimeSpan RetryInterval { get; set; }
        public int MaxOfExceptionsToCircuitBreak { get; set; }
        public TimeSpan IntervalCircuitBreak { get; set; }
    }
}