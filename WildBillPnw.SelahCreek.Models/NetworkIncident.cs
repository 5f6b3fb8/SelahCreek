using System.Text.Json.Serialization;

namespace WildBillPnw.SelahCreek.Models
{
    /*
     * Example Payload
     *  {'n':12345,'c':'INC12345','b':'brief description','d':'details','p':5}
     */
    public class NetworkIncident
    {
        [JsonPropertyName("n")]
        public string Number { get; set; }

        [JsonPropertyName("c")]
        public string CorrelationId { get; set; }

        [JsonPropertyName("b")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("d")]
        public string Description { get; set; }

        [JsonPropertyName("p")]
        public NetworkIncidentPriority Priority { get; set; }

        [JsonPropertyName("s")]
        public NetworkIncidentState State { get; set; }
    }
}
