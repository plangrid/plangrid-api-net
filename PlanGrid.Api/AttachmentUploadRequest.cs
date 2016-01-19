// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace PlanGrid.Api
{
    public class AttachmentUploadRequest
    {
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("aws_post_form_arguments")]
        public AwsPostFormArguments AwsPostFormArguments { get; set; }
    }
}
