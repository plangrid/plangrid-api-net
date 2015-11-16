using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class RfiStatus
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
