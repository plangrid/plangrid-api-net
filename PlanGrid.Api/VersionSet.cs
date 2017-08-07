// <copyright file="Project.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2017 PlanGrid, Inc. All rights reserved.
// </copyright>
using System;
using Newtonsoft.Json;


namespace PlanGrid.Api
{
    public class VersionSet : Record
    {
        [JsonProperty("version_name")]
        public string Name { get; set; }

        [JsonProperty("published_at")]
        public DateTime? PublishDate { get; set; }
    }
}