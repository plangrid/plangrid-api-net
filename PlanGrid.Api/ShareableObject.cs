using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class ShareableObject
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("file_url")]
        public string FileUrl { get; set; }

        [JsonProperty("resource")]
        public ShareableObject Resource { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
