using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Sheet : Record
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version_name")]
        public string VersionName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("published_by")]
        public UserReference PublishedBy { get; set; }

        [JsonProperty("published_at")]
        public DateTime? PublishedAt { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("uploaded_file_name")]
        public string UploadedFileName { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PublishedAt} by {PublishedBy.Email})";
        }
    }
}
