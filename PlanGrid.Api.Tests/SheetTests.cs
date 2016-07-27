// <copyright file="SheetTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class SheetTests
    {
        [Test]
        public async Task GetSheets()
        {
            IPlanGridApi client = PlanGridClient.Create();

            Page<Sheet> sheets = await client.GetSheets(TestData.Project1Uid);

        }
    }
}