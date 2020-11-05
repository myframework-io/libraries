using System;

namespace Myframework.Libraries.Application.Options
{
    public class TranslationOptions
    {
        public bool Enabled { get; set; }
        public string BaseUrl { get; set; }
        public string ResultTranslateRoute { get; set; }
        public bool ThrowExceptionWhenErrorOcurrInTranslate { get; set; }
        public TimeSpan? ApiTimeout { get; set; }
        public TimeSpan CacheTimeoutForSuccessResultTranslation { get; set; }
    }
}