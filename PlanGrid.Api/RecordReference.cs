// <copyright file="RecordReference.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class RecordReference<T> where T : Record
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
