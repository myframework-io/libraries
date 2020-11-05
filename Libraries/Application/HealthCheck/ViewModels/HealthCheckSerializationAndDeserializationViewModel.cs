using System;
using System.Text.Json.Serialization;

namespace Myframework.Libraries.Application.HealthCheck.ViewModels
{
    public class HealthCheckSerializationAndDeserializationViewModel
    {
        public int PropInt { get; set; }
        public int? PropIntNullable { get; set; }
        public decimal PropDecimal { get; set; }
        public decimal? PropDecimalNullable { get; set; }
        public DateTime PropDateTime { get; set; }
        public DateTime? PropDateTimeNullable { get; set; }
        public string PropString { get; set; }
        public string CurrentCulture { get; set; }
        [JsonIgnore] public int PropIgnored { get; set; }
    }
}