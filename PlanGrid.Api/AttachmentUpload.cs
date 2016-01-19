// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AttachmentUpload
    {
        public const string Pdf = "application/pdf";

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }
    }
}
