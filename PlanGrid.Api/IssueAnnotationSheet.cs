// <copyright file="IssueAnnotationSheet.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class IssueAnnotationSheet
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version_name")]
        public string VersionName { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
    }
}
