// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AwsPostFormArgument
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
