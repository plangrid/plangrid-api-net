// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AwsPostFormArguments
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("fields")]
        public AwsPostFormArgument[] Fields { get; set; }
    }
}
