using System.Net;

namespace PlanGrid.Api
{
    public class RateLimitExceededException : FailedRequestException
    {
        public RateLimit RateLimit { get; set; }

        public RateLimitExceededException(HttpStatusCode statusCode, string message, RateLimit rateLimit) : base(statusCode, message)
        {
            RateLimit = rateLimit;
        }
    }
}
