// <copyright file="Comment.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Comment
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public UserReference CreatedBy { get; set; }
    }
}
