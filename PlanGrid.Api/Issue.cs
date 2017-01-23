// <copyright file="Issue.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Issue : Record
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("current_annotation")]
        public Annotation CurrentAnnotation { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("assigned_to")]
        public UserReference[] AssignedTo { get; set; }

        [JsonProperty("status")]
        public IssueStatus Status { get; set; }

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

        [JsonProperty("comments")]
        public CollectionReference<Comment> Comments { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
    }
}
