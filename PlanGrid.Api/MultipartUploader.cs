// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlanGrid.Api
{
    public class MultipartUploader
    {
        public static async Task<HttpResponseMessage> Upload(string url, CancellationToken cancellationToken, params IMultipartContent[] values)
        {
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = true }))
            {
                string boundary = "----" + DateTime.Now.Ticks;

                var content = new MultipartFormDataContent(boundary);
                foreach (IMultipartContent item in values)
                {
                    item.CreateContent(content);
                }

                HttpResponseMessage response = await client.PostAsync(new Uri(url), content, cancellationToken);
                if ((int)response.StatusCode >= 400)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new MultipartUploadException($"Error uploading attachment to S3: {message}");
                }
                return response;
            }
        }
    }
}
