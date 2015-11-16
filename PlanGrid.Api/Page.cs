// <copyright file="Page.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public static class Page
    {
        public const int Skip = 0;
        public const int Limit = 50;
    }

    public class Page<T>
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("next_page_url")]
        public string NextPageUrl { get; set; }

        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
}