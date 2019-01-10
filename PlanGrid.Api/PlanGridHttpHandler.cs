// <copyright file="PlanGridHttpHandler.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace PlanGrid.Api
{
    public class PlanGridHttpHandler : HttpClientHandler
    {
        public const HttpStatusCode RateLimitExceeded = (HttpStatusCode)429;

        private string authenticationToken;
        private RefitSettings settings;
        private string version;
        private int? maxRetries;

        public PlanGridHttpHandler(string accessToken, RefitSettings settings, string version, int? maxRetries)
        {
            authenticationToken = BuildAuthenticationToken(accessToken);
            this.settings = settings;
            this.version = version;
            this.maxRetries = maxRetries;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            for (int i = 1; i < (maxRetries ?? int.MaxValue); i *= 2)
            {
                // The following is a hack to workaround the fact that the API currently requires a content-type on POST
                // requests that contain no content.
                if (request.Content == null && request.Method == HttpMethod.Post)
                {
                    request.Content = new StringContent("", Encoding.UTF8, "application/json");
                }

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse($"application/vnd.plangrid+json; version={version}"));

                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    await Task.Delay(i * 1000, cancellationToken);
                    continue;
                }

                if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == RateLimitExceeded)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    FailedRequestResponse json;
                    try
                    {
                        json = JsonConvert.DeserializeObject<FailedRequestResponse>(jsonString, settings.JsonSerializerSettings);
                    }
                    catch (Exception ex)
                    {
                        throw new FailedRequestException(response.StatusCode, $"Failed to parse response from server: {jsonString}", ex);
                    }
                    if (response.StatusCode == RateLimitExceeded)
                    {
                        throw new RateLimitExceededException(response.StatusCode, json.Message, json.RateLimit);
                    }
                    else
                    {
                        throw new FailedRequestException(response.StatusCode, json.Message);
                    }
                }

                return response;
            }
            throw new FailedRequestException(HttpStatusCode.ServiceUnavailable, $"Service unavailable after retrying {maxRetries} times.");
        }

        private string BuildAuthenticationToken(string accessToken)
        {
            string unencoded = $"{accessToken}:";
            byte[] authParamBytes = Encoding.ASCII.GetBytes(unencoded);
            string encodedAuthParams = Convert.ToBase64String(authParamBytes);
            return encodedAuthParams;
        }
    }
}
