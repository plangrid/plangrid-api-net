// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Net.Http;
using System.Net.Http.Headers;

namespace PlanGrid.Api
{
    public class StringMultipartContent : IMultipartContent
    {
        public string Name { get; }
        public string Value { get; }

        public StringMultipartContent(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public void CreateContent(MultipartFormDataContent multipart)
        {
            var content = new StringContent(Value);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
            multipart.Add(content, Name);
        }
    }
}
