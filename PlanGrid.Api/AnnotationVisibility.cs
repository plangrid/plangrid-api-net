// <copyright file="AnnotationVisibility.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum AnnotationVisibility
    {
        None,

        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "master")]
        Master
    }
}
