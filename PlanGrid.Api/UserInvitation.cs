// <copyright file="UserInvitation.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class UserInvitation
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role_uid")]
        public string RoleUid { get; set; }
    }
}
