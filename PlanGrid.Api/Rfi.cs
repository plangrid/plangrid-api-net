// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Rfi : Record
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("status")]
        public RfiStatus Status { get; set; }

        [JsonProperty("locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("assigned_to")]
        public UserReference[] AssignedTo { get; set; }

        [JsonProperty("sent_at")]
        public DateTime? SentAt { get; set; }

        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public UserReference CreatedBy { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("updated_by")]
        public UserReference UpdatedBy { get; set; }

        [JsonProperty("photos")]
        public CollectionReference<Photo> Photos { get; set; }

        [JsonProperty("snapshots")]
        public CollectionReference<Snapshot> Snapshots { get; set; }

        [JsonProperty("attachments")]
        public CollectionReference<Attachment> Attachments { get; set; }

        [JsonProperty("comments")]
        public CollectionReference<Comment> Comments { get; set; }
    }
}
