// <copyright file="RfisTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Linq;
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
            Assert.AreEqual(DateTime.Parse("11/18/2015 19:30:21.000"), rfi.SentDate);
            Assert.AreEqual(DateTime.Parse("11/19/2015 19:30:13.000"), rfi.DueDate);
            Assert.AreEqual(DateTime.Parse("11/17/2015 20:06:47.912"), rfi.UpdatedAt);
            Assert.AreEqual(DateTime.Parse("11/16/2015 21:48:26.641"), rfi.CreatedAt);
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
        public async Task UpdateRfiStatuses()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<RfiStatus> statuses = await client.GetRfiStatuses(TestData.Project1Uid);
            Assert.AreEqual("draft", statuses.Data[0].Label);
            await client.UpdateRfiStatus(TestData.Project1Uid, statuses.Data[0].Uid, new RfiStatusUpdate { Label = "draft2" });
            statuses = await client.GetRfiStatuses(TestData.Project1Uid);
            Assert.AreEqual("draft2", statuses.Data[0].Label);
            await client.UpdateRfiStatus(TestData.Project1Uid, statuses.Data[0].Uid, new RfiStatusUpdate { Label = "draft" });
            statuses = await client.GetRfiStatuses(TestData.Project1Uid);
            Assert.AreEqual("draft", statuses.Data[0].Label);
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

        [Test]
        public async Task CreateRfi()
        {
            IPlanGridApi client = PlanGridClient.Create();
            var rfiInsert = new RfiUpsert
            {
                Question = "test question",
                Answer = "test answer",
                AssignedTo = new[] { TestData.ApiTestsUserUid },
                DueDate = new DateTime(2020, 1, 1),
                IsLocked = true,
                SentDate = new DateTime(2019, 1, 1),
                StatusUid = TestData.Project2DraftRfiStatusUid,
                Title = "test title"
            };
            Rfi rfi = await client.CreateRfi(TestData.Project2Uid, rfiInsert);
            Assert.AreEqual(rfiInsert.Question, rfi.Question);
            Assert.AreEqual(rfiInsert.Answer, rfi.Answer);
            Assert.AreEqual(rfiInsert.AssignedTo[0], rfi.AssignedTo[0].Uid);
            Assert.AreEqual(rfiInsert.DueDate, rfi.DueDate);
            Assert.AreEqual(rfiInsert.IsLocked, rfi.IsLocked);
            Assert.AreEqual(rfiInsert.SentDate, rfi.SentDate);
            Assert.AreEqual(rfiInsert.StatusUid, rfi.Status.Uid);
            Assert.AreEqual(rfiInsert.Title, rfi.Title);
            Assert.AreEqual(TestData.ApiTestsUserUid, rfi.CreatedBy.Uid);
            Assert.AreNotEqual(rfi.CreatedAt, default(DateTime));
            Assert.AreEqual(TestData.ApiTestsUserUid, rfi.UpdatedBy.Uid);
            Assert.AreNotEqual(rfi.UpdatedAt, default(DateTime));
        }

        [Test]
        public async Task UpdateRfi()
        {
            IPlanGridApi client = PlanGridClient.Create();
            var rfiInsert = new RfiUpsert
            {
                Question = "test question",
                Answer = "test answer",
                AssignedTo = new[] { TestData.ApiTestsUserUid },
                DueDate = new DateTime(2020, 1, 1),
                IsLocked = true,
                SentDate = new DateTime(2019, 1, 1),
                StatusUid = TestData.Project2DraftRfiStatusUid,
                Title = "test title"
            };
            Rfi rfi = await client.CreateRfi(TestData.Project2Uid, rfiInsert);

            var rfiUpdate = new RfiUpsert
            {
                Question = "test question2",
                Answer = "test answer2",
                AssignedTo = new[] { TestData.ApiTestsUser2Uid },
                DueDate = new DateTime(2020, 1, 2),
                IsLocked = false,
                SentDate = new DateTime(2019, 1, 2),
                StatusUid = TestData.Project2OpenRfiStatusUid,
                Title = "test title2"
            };
            rfi = await client.UpdateRfi(TestData.Project2Uid, rfi.Uid, rfiUpdate);

            Assert.AreEqual(rfiUpdate.Question, rfi.Question);
            Assert.AreEqual(rfiUpdate.Answer, rfi.Answer);
            Assert.AreEqual(rfiUpdate.AssignedTo[0], rfi.AssignedTo[0].Uid);
            Assert.AreEqual(rfiUpdate.DueDate, rfi.DueDate);
            Assert.AreEqual(rfiUpdate.IsLocked, rfi.IsLocked);
            Assert.AreEqual(rfiUpdate.SentDate, rfi.SentDate);
            Assert.AreEqual(rfiUpdate.StatusUid, rfi.Status.Uid);
            Assert.AreEqual(rfiUpdate.Title, rfi.Title);
            Assert.AreEqual(TestData.ApiTestsUserUid, rfi.CreatedBy.Uid);
            Assert.AreNotEqual(rfi.CreatedAt, default(DateTime));
            Assert.AreEqual(TestData.ApiTestsUserUid, rfi.UpdatedBy.Uid);
            Assert.AreNotEqual(rfi.UpdatedAt, default(DateTime));
        }

        [Test]
        public async Task ReferenceAttachment()
        {
            IPlanGridApi client = PlanGridClient.Create();
            var rfiInsert = new RfiUpsert
            {
                Question = "test question",
                Answer = "test answer",
                AssignedTo = new[] { TestData.ApiTestsUserUid },
                DueDate = new DateTime(2020, 1, 1),
                IsLocked = false,
                SentDate = new DateTime(2019, 1, 1),
                StatusUid = TestData.Project2DraftRfiStatusUid,
                Title = "test title"
            };
            Rfi rfi = await client.CreateRfi(TestData.Project2Uid, rfiInsert);

            AttachmentUploadRequest request = await client.CreateAttachmentUploadRequest(TestData.Project2Uid, new AttachmentUpload
            {
                ContentType = AttachmentUpload.Pdf,
                Name = "test name",
                Folder = "test folder"
            });

            Stream payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
            Attachment attachment = await client.Upload(request, payload);

            await client.ReferenceAttachmentFromRfi(TestData.Project2Uid, rfi.Uid, new AttachmentReference { AttachmentUid = attachment.Uid });

            Page<Attachment> attachments = await client.GetRfiAttachments(TestData.Project2Uid, rfi.Uid);
            Attachment rfiAttachment = attachments.Data.Single();
            Assert.AreEqual(attachment.Uid, rfiAttachment.Uid);
        }

        [Test]
        public async Task ReferencePhoto()
        {
            IPlanGridApi client = PlanGridClient.Create();
            var rfiInsert = new RfiUpsert
            {
                Question = "test question",
                Answer = "test answer",
                AssignedTo = new[] { TestData.ApiTestsUserUid },
                DueDate = new DateTime(2020, 1, 1),
                IsLocked = false,
                SentDate = new DateTime(2019, 1, 1),
                StatusUid = TestData.Project2DraftRfiStatusUid,
                Title = "test title"
            };
            Rfi rfi = await client.CreateRfi(TestData.Project2Uid, rfiInsert);

            await client.ReferencePhotoFromRfi(TestData.Project2Uid, rfi.Uid, new PhotoReference { PhotoUid = TestData.Project2PhotoUid });

            Page<Photo> photos = await client.GetRfiPhotos(TestData.Project2Uid, rfi.Uid);
            Photo rfiPhoto = photos.Data.Single();
            Assert.AreEqual(TestData.Project2PhotoUid, rfiPhoto.Uid);
        }
    }
}