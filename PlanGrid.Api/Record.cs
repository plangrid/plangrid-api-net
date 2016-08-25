using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public abstract class Record
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
    }
}
