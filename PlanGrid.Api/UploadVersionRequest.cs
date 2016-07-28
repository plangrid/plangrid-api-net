using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class UploadVersionRequest
    {
        [JsonProperty("num_files")]
        public int NumberOfFiles { get; set; }

        [JsonProperty("version_name")]
        public string VersionName { get; set; }
    }
}
