// <copyright file="PhotoUpdate.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class PhotoUpdate
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
