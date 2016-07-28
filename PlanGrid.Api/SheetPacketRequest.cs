using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class SheetPacketRequest
    {
        [JsonProperty("sheet_uids")]
        public string[] SheetUids { get; set; }
    }
}
