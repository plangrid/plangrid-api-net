using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class FileUploadRequest
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("status")]
        public FileUploadRequestStatus Status { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
