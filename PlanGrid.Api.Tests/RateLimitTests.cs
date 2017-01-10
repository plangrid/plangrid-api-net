// <copyright file="RateLimitTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class RateLimitTests
    {
        [Test]
        public async Task HitRateLimit()
        {
            IPlanGridApi client = PlanGridClient.Create(TestData.RateLimitedPlanGridApiKey);
            try
            {
                await client.GetProjects();
            }
            catch
            {
                // The rate limit for this user is 1 per day.  So the first one might succeed, or it might not.
            }

            try
            {
                await client.GetProjects();
                Assert.Fail("Should have exceeded the rate limit");
            }
            catch (RateLimitExceededException ex)
            {
                Assert.AreEqual(1, ex.RateLimit.Limit);
                Assert.AreEqual(0, ex.RateLimit.Remaining);
                Assert.AreEqual(RequestType.All, ex.RateLimit.RequestType);
                Assert.AreNotEqual(DateTime.MinValue, ex.RateLimit.Reset);
                Assert.AreEqual(86400, ex.RateLimit.Interval);  // 1 day
            }
        }
    }
}