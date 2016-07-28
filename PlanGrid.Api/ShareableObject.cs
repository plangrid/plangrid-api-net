using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class ShareableObject
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("file_url")]
        public string FileUrl { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
