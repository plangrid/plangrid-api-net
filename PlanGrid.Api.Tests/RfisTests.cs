// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class RfisTests
    {
        [Test]
        public async Task GetRfis()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Rfi> rfis = await client.GetRfis(TestData.Project1Uid);
            Assert.AreEqual(1, rfis.TotalCount);

            Rfi rfi = rfis.Data[0];
            Assert.AreEqual("Test Rfi Answer", rfi.Answer);
            Assert.AreEqual("Test Rfi Question", rfi.Question);
            Assert.AreEqual("Test Rfi", rfi.Title);
            Assert.AreEqual(1, rfi.Number);
            Assert.AreEqual(DateTime.Parse("11/18/2015 11:30:21.000"), rfi.SentDate);
            Assert.AreEqual(DateTime.Parse("11/19/2015 11:30:13.000"), rfi.DueDate);
            Assert.AreEqual(DateTime.Parse("11/17/2015 12:06:47.912"), rfi.UpdatedAt);
            Assert.AreEqual(DateTime.Parse("11/16/2015 13:48:26.641"), rfi.CreatedAt);
            Assert.AreEqual("kirk+apitests@plangrid.com", rfi.AssignedTo[0].Email);
            Assert.AreEqual("kirk+apitests@plangrid.com", rfi.UpdatedBy.Email);
            Assert.AreEqual("kirk+apitests@plangrid.com", rfi.CreatedBy.Email);
            Assert.IsFalse(string.IsNullOrEmpty(rfi.Uid));
            Assert.IsTrue(rfi.IsLocked);

            Page<Photo> photos = await client.Resolve(rfi.Photos);
            Assert.AreEqual(1, rfi.Photos.TotalCount);
            Assert.AreEqual(1, photos.TotalCount);
            Assert.AreEqual(TestData.PhotoUrl, photos.Data[0].Url);

            Page<Snapshot> snapshots = await client.Resolve(rfi.Snapshots);
            Assert.AreEqual(1, rfi.Snapshots.TotalCount);
            Assert.AreEqual(1, snapshots.TotalCount);
            Assert.AreEqual("AR.1", snapshots.Data[0].Title);

            Page<Attachment> attachments = await client.Resolve(rfi.Attachments);
            Assert.AreEqual(1, rfi.Attachments.TotalCount);
            Assert.AreEqual(1, attachments.TotalCount);
            Assert.AreEqual("PA1.11.pdf", attachments.Data[0].Name);

            Page<Comment> comments = await client.Resolve(rfi.Comments);
            Assert.AreEqual(1, rfi.Comments.TotalCount);
            Assert.AreEqual(1, comments.TotalCount);
            Assert.AreEqual("Test Rfi Comment", comments.Data[0].Text);
        }

        [Test]
        public async Task GetRfiStatuses()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<RfiStatus> statuses = await client.GetRfiStatuses(TestData.Project1Uid);
            Assert.AreEqual(6, statuses.TotalCount);
            Assert.AreEqual("draft", statuses.Data[0].Label);
            Assert.AreEqual("#34b27d", statuses.Data[0].Color);
        }

        [Test]
        public async Task GetRfiComments()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Comment> comments = await client.GetRfiComments(TestData.Project1Uid, TestData.Project1Rfi1Uid);
            Assert.AreEqual(1, comments.TotalCount);
            Assert.AreEqual("Test Rfi Comment", comments.Data[0].Text);
        }

        [Test]
        public async Task GetRfiPhotos()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Photo> photos = await client.GetRfiPhotos(TestData.Project1Uid, TestData.Project1Rfi1Uid);
            Assert.AreEqual(1, photos.TotalCount);
            Assert.AreEqual(TestData.PhotoUrl, photos.Data[0].Url);
        }

        [Test]
        public async Task GetRfiSnapshots()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Snapshot> snapshots = await client.GetRfiSnapshots(TestData.Project1Uid, TestData.Project1Rfi1Uid);
            Assert.AreEqual(1, snapshots.TotalCount);
            Assert.AreEqual("AR.1", snapshots.Data[0].Title);
        }

        [Test]
        public async Task GetRfiAttachments()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Attachment> attachments = await client.GetRfiAttachments(TestData.Project1Uid, TestData.Project1Rfi1Uid);
            Assert.AreEqual(1, attachments.TotalCount);
            Assert.AreEqual("PA1.11.pdf", attachments.Data[0].Name);
        }
    }
}