// <copyright file="Role.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Role : Record
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
