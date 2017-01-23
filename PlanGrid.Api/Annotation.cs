// <copyright file="Annotation.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class Annotation
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("stamp")]
        public string Stamp { get; set; }

        [JsonProperty("visibility")]
        public AnnotationVisibility Visibility { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("sheet")]
        public RecordReference<Sheet> Sheet { get; set; }
    }
}
