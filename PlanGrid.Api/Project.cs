// <copyright file="Project.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Project : Record
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}