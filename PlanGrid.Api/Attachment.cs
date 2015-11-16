// <copyright file="Attachment.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Attachment
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public UserReference CreatedBy { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
    }
}
