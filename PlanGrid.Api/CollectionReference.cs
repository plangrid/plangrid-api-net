// <copyright file="CollectionReference.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class CollectionReference<T>
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
