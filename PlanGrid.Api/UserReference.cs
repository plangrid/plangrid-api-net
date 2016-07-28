// <copyright file="UserReference.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class UserReference : RecordReference<User>
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
