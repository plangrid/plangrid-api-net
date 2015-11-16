// <copyright file="PlanGridHttpHandler.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanGrid.Api
{
    public class PlanGridHttpHandler : HttpClientHandler
    {
        private string authenticationToken;

        public PlanGridHttpHandler(string accessToken)
        {
            authenticationToken = BuildAuthenticationToken(accessToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authenticationToken);

            return base.SendAsync(request, cancellationToken);
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