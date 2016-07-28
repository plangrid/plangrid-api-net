using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class PhotoUpload
    {
        public const string Jpeg = "image/jpeg";
        public const string Png = "image/png";

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("title")]
        public string Title{ get; set; }
    }
}
