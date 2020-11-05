using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Myframework.Libraries.Application.ApplicationInsights
{
    /// <summary>
    /// Initializer para obter dados do contexto Http para logar no Application Insights.
    /// </summary>
    public class HttpContextRequestTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContextRequestTelemetryInitializer(IHttpContextAccessor httpContextAccessor) =>
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry == null) return;

            Claim userNameClaim = httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(claim => claim.Type == "preferred_username");

            requestTelemetry.Properties.Add("UserName", userNameClaim?.Value);
            requestTelemetry.Properties.Add("InternalOrigin", httpContextAccessor.HttpContext.Request.Headers["InternalOrigin"].ToString());
            requestTelemetry.Properties.Add("Protocol", httpContextAccessor.HttpContext.Request.Headers["Protocol"].ToString());

            Claim exp = httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(claim => claim.Type == "exp");

            if (exp != null && int.TryParse(exp.Value, out int expInt))
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                epoch = epoch.AddSeconds(expInt);
                requestTelemetry.Properties.Add("AccessTokenExpired", (epoch < DateTime.UtcNow).ToString());
            }
        }
    }
}