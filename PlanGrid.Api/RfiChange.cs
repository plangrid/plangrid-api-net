using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlanGrid.Api
{
    public class RfiChange
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("old_value")]
        public JToken OldValue { get; set; }

        [JsonProperty("new_value")]
        public JToken NewValue { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("updated_by")]
        public UserReference UpdatedBy { get; set; }
    }
}
