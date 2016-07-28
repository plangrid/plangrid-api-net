// <copyright file="SheetPacketTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class SheetPacketTests
    {
        [Test]
        public async Task CreateSheetPacket()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Sheet> sheets = await client.GetSheets(TestData.Project2Uid);
            ShareableObject packetRequest = await client.CreateSheetPacket(TestData.Project2Uid, new SheetPacketRequest
            {
                SheetUids = new[] { sheets.Data[0].Uid }
            });

            for (int i = 0;; i++)
            {
                ShareableObject obj = await client.GetSheetPacket(TestData.Project2Uid, packetRequest.Uid);
                if (obj.Status == Status.Incomplete)
                {
                    if (i == 10)
                    {
                        Assert.Fail("Timed out after 10 seconds trying to get the packet.");
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                }
                else
                {
                    var get = new HttpClient();
                    HttpResponseMessage response = await get.GetAsync(obj.FileUrl);
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    break;
                }
            }
        }
    }
}