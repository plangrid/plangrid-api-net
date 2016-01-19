using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class RfiStatusUpdate
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
