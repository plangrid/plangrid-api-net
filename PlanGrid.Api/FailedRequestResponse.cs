using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class FailedRequestResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
