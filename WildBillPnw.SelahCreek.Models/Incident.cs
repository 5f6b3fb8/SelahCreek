using System.Text.Json.Serialization;

namespace WildBillPnw.SelahCreek.Models
{
    public class Incident
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("correlation_id")]
        public string CorrelationId { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("priority")]
        public IncidentPriority Priority { get; set; }

        [JsonPropertyName("state")]
        public IncidentState State { get; set; }

        [JsonPropertyName("hold_reason")]
        public IncidentHoldReason HoldReason { get; set; }
    }
}
