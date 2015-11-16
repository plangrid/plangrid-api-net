// <copyright file="IssueStatus.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum IssueStatus
    {
        None,

        [EnumMember(Value = "open")]
        Open,

        [EnumMember(Value = "in_review")]
        InReview,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "closed")]
        Closed
    }
}
