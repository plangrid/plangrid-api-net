﻿// <copyright file="SheetTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class SheetTests
    {
        [Test]
        public async Task GetSheet()
        {
            IPlanGridApi client = PlanGridClient.Create();

            Sheet sheet = await client.GetSheet(TestData.Project1Uid, "8e860282-2e05-4011-a538-d0a850857903");
            Assert.AreEqual("IS.1", sheet.Name);
        }

        [Test]
        public async Task GetSheetsObeysSkip()
        {
            IPlanGridApi client = PlanGridClient.Create();

            Page<Sheet> sheets = await client.GetSheets(TestData.Project1Uid);
            Assert.AreEqual("IS.1", sheets.Data[0].Name);
            Assert.AreEqual("PA8.21", sheets.Data[1].Name);
            sheets = await client.GetSheets(TestData.Project1Uid, 1);
            Assert.AreEqual("PA8.21", sheets.Data[0].Name);
        }

        [Test]
        public async Task GetSheetsObeysUpdatedAfter()
        {
            IPlanGridApi client = PlanGridClient.Create();

            Page<Sheet> sheets = await client.GetSheets(TestData.Project1Uid, updated_after: new DateTime(2015, 12, 11, 19, 38, 16, DateTimeKind.Utc));
            Assert.IsTrue(sheets.Data.Any());
            sheets = await client.GetSheets(TestData.Project1Uid, updated_after: new DateTime(2016, 12, 11, 19, 39, 16, DateTimeKind.Utc));
            Assert.IsFalse(sheets.Data.Any());
        }

        [Test]
        public async Task UploadNewVersion()
        {
            IPlanGridApi client = PlanGridClient.Create();

            await client.UploadVersion(TestData.Project2Uid, $"Version.{Guid.NewGuid()}", new VirtualFile { FileName = "Sample.pdf", Data = typeof(SheetTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf") });
        }

        [Test]
        public async Task GetSheetsByVersionSet()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Sheet> sheets = await client.GetSheets(TestData.Project1Uid, version_set: TestData.Project1VersionSet1Uid);
            Assert.Less(0, sheets.Data.Length);
            Page<Sheet> sheets_empty = await client.GetSheets(TestData.Project1Uid, version_set: TestData.NotFoundUid);
            Assert.AreEqual(0, sheets_empty.Data.Length);
        }
    }
}