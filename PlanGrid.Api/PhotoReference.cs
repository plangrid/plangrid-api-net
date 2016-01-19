using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class PhotoReference
    {
        [JsonProperty("photo_uid")]
        public string PhotoUid { get; set; }
    }
}
