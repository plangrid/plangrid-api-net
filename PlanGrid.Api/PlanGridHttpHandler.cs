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
        private string authenticationToken;
        private RefitSettings settings;

        public PlanGridHttpHandler(string accessToken, RefitSettings settings)
        {
            authenticationToken = BuildAuthenticationToken(accessToken);
            this.settings = settings;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // The following is a hack to workaround the fact that the API currently requires a content-type on POST
            // requests that contain no content.
            if (request.Content == null && request.Method == HttpMethod.Post)
            {
                request.Content = new StringContent("", Encoding.UTF8, "application/json");
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationToken);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/vnd.plangrid+json; version=1"));

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<FailedRequestResponse>(jsonString, settings.JsonSerializerSettings);
                throw new FailedRequestException(response.StatusCode, json.Message);
            }

            return response;
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