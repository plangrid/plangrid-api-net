using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AttachmentUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }
    }
}
