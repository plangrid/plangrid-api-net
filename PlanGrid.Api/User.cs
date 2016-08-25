// <copyright file="User.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class User : Record
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role")]
        public RecordReference<Role> Role { get; set; }

        [JsonProperty("removed")]
        public bool IsRemoved { get; set; }
    }
}
