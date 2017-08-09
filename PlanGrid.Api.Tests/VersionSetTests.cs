// <copyright file="VersionSetTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2017 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class VersionSetTests
    {
        [Test]
        public async Task GetVersionSets()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<VersionSet> versionSets = await client.GetVersionSets(TestData.Project1Uid);
            Assert.AreEqual(1, versionSets.Data.Length);
            VersionSet versionSet = versionSets.Data[0];
            Assert.AreEqual(TestData.VersionSet1Uid, versionSet.Uid);
            Assert.AreEqual(TestData.VersionSet1Name, versionSet.Name);
            Assert.AreEqual(TestData.VersionSet1PublishDate, versionSet.PublishDate);
        }
    }
}