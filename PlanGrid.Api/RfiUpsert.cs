// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class RfiUpsert
    {
        [JsonProperty("status")]
        public string StatusUid { get; set; }

        [JsonProperty("locked")]
        public bool? IsLocked { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("sent_date")]
        public Date? SentDate { get; set; }

        [JsonProperty("due_date")]
        public Date? DueDate { get; set; }

        [JsonProperty("assigned_to")]
        public string[] AssignedTo { get; set; }
    }
}
