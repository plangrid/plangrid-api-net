using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class UploadFile
    {
        [JsonProperty("file_name")]
        public string FileName { get; set; }
    }
}
