using System;
using System.Net;

namespace PlanGrid.Api
{
    public class FailedRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public FailedRequestException(HttpStatusCode statusCode, string message) : base($"{(int)statusCode} ({statusCode}): {message}")
        {
            StatusCode = statusCode;
        }

        public FailedRequestException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
