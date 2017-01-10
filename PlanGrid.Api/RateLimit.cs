using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class RateLimit
    {
        [JsonProperty("request_type")]
        public RequestType RequestType { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }

        [JsonProperty("reset")]
        public DateTime Reset { get; set; }
    }
}