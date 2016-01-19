// <copyright file="Role.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Role
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
