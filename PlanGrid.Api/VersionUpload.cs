using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class VersionUpload
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("complete_url")]
        public string CompleteUrl { get; set; }

        [JsonProperty("status")]
        public VersionUploadStatus Status { get; set; }

        [JsonProperty("file_upload_requests")]
        public FileUploadRequest[] FileUploadRequests { get; set; }
    }
}
