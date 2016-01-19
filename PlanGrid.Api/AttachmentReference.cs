using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AttachmentReference
    {
        [JsonProperty("attachment_uid")]
        public string AttachmentUid { get; set; }
    }
}
