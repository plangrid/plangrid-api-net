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
            await ValidateRfi(rfi, client);
        }

        [Test]
        public async Task GetRfi()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Rfi rfi = await client.GetRfi(TestData.Project1Uid, TestData.Project1Rfi1Uid);
            await ValidateRfi(rfi, client);
        }

        private async Task ValidateRfi(Rfi rfi, IPlanGridApi client)
        {
            Page<RfiChange> history = await client.GetRfiHistory(TestData.Project1Uid, rfi.Uid);
            Assert.AreEqual("locked", history.Data[0].Field);
            Assert.AreEqual(true, (bool)history.Data[0].NewValue);
            Assert.AreEqual(false, (bool)history.Data[0].OldValue);

            Assert.AreEqual("Test Rfi Answer", rfi.Answer);
            Assert.AreEqual("Test Rfi Question", rfi.Question);
            Assert.AreEqual("Test Rfi", rfi.Title);
            Assert.AreEqual(1, rfi.Number);
            Assert.AreEqual(Date.Parse("2015-11-18"), rfi.SentDate);
            Assert.AreEqual(Date.Parse("2015-11-19"), rfi.DueDate);
            Assert.AreEqual(DateTime.Parse("11/17/2015 20:06:48.115"), rfi.UpdatedAt);
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

            FileUpload request = await client.CreateAttachmentUploadRequest(TestData.Project2Uid, new AttachmentUpload
            {
                ContentType = AttachmentUpload.Pdf,
                Name = "test name",
                Folder = "test folder"
            });

            Stream payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
            Attachment attachment = await client.Upload<Attachment>(request, payload);

            await client.ReferenceAttachmentFromRfi(TestData.Project2Uid, rfi.Uid, new AttachmentReference { AttachmentUid = attachment.Uid });

            Page<Attachment> attachments = await client.GetRfiAttachments(TestData.Project2Uid, rfi.Uid);
            Attachment rfiAttachment = attachments.Data.Single();
            Assert.AreEqual(attachment.Uid, rfiAttachment.Uid);

            await client.RemoveAttachmentFromRfi(TestData.Project2Uid, rfi.Uid, rfiAttachment.Uid);

            attachments = await client.GetRfiAttachments(TestData.Project2Uid, rfi.Uid);
            Assert.AreEqual(0, attachments.Data.Length);
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

            await client.RemovePhotoFromRfi(TestData.Project2Uid, rfi.Uid, rfiPhoto.Uid);

            photos = await client.GetRfiPhotos(TestData.Project2Uid, rfi.Uid);
            Assert.AreEqual(0, photos.Data.Length);
        }

/*
The API does not currently support adding a reference to a snapshot, so we can't make a re-runnable test
        [Test]
        public async Task RemoveSnapshotFromRfi()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Rfi rfi = await client.GetRfi(TestData.Project2Uid, "b1ea01e7-ecf1-473d-8cfe-a366e240dc67");
            Page<Snapshot> attachments = await client.Resolve(rfi.Snapshots);
            Assert.AreEqual(1, attachments.Data.Length);
            await client.RemoveSnapshotFromRfi(TestData.Project2Uid, "b1ea01e7-ecf1-473d-8cfe-a366e240dc67", "0fe94c7e-30c6-4c30-81bd-0cec483cf813");
            attachments = await client.Resolve(rfi.Snapshots);
            Assert.AreEqual(0, attachments.Data.Length);
        }
*/
    }
}