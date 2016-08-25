// <copyright file="AttachmentTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
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
    public class AttachmentTests
    {
        [Test]
        public async Task UploadAttachment()
        {
            IPlanGridApi client = PlanGridClient.Create();
            FileUpload request = await client.CreateAttachmentUploadRequest(TestData.Project2Uid, new AttachmentUpload
            {
                ContentType = AttachmentUpload.Pdf,
                Name = "test name",
                Folder = "test folder"
            });

            Stream payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
            Attachment attachment = await client.Upload<Attachment>(request, payload);

            Assert.AreEqual("test name", attachment.Name);
            Assert.AreEqual("test folder", attachment.Folder);
            Assert.AreEqual(TestData.ApiTestsUserUid, attachment.CreatedBy.Uid);
            Assert.AreNotEqual(attachment.CreatedAt, default(DateTime));
            Assert.AreEqual(request.Uid, attachment.Uid);

            using (var downloader = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = true }))
            {
                Stream returnedPayload = await downloader.GetStreamAsync(attachment.Url);
                payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
                var payloadBytes = new MemoryStream();
                await payload.CopyToAsync(payloadBytes);
                var returnedBytes = new MemoryStream();
                await returnedPayload.CopyToAsync(returnedBytes);
                Assert.IsTrue(payloadBytes.ToArray().SequenceEqual(returnedBytes.ToArray()));
            }

            Attachment retrievedAttachment = await client.GetAttachment(TestData.Project2Uid, attachment.Uid);
            Assert.IsFalse(retrievedAttachment.IsDeleted);
            await client.RemoveAttachment(TestData.Project2Uid, attachment.Uid);
            Attachment removedAttachment = await client.GetAttachment(TestData.Project2Uid, attachment.Uid);
            Assert.IsTrue(removedAttachment.IsDeleted);
        }

        [Test]
        public async Task UploadPdfAttachment()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Stream payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
            Attachment attachment = await client.UploadPdfAttachment(TestData.Project2Uid, "test name", payload, "test folder");

            Assert.AreEqual("test name", attachment.Name);
            Assert.AreEqual("test folder", attachment.Folder);
            Assert.AreEqual(TestData.ApiTestsUserUid, attachment.CreatedBy.Uid);
            Assert.AreNotEqual(attachment.CreatedAt, default(DateTime));

            using (var downloader = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = true }))
            {
                Stream returnedPayload = await downloader.GetStreamAsync(attachment.Url);
                payload = typeof(AttachmentTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.pdf");
                var payloadBytes = new MemoryStream();
                await payload.CopyToAsync(payloadBytes);
                var returnedBytes = new MemoryStream();
                await returnedPayload.CopyToAsync(returnedBytes);
                Assert.IsTrue(payloadBytes.ToArray().SequenceEqual(returnedBytes.ToArray()));
            }

            Attachment retrievedAttachment = await client.GetAttachment(TestData.Project2Uid, attachment.Uid);
            Assert.IsFalse(retrievedAttachment.IsDeleted);
            await client.UpdateAttachment(TestData.Project2Uid, attachment.Uid, new AttachmentUpdate { Name = "new name", Folder = "new folder" });
            retrievedAttachment = await client.GetAttachment(TestData.Project2Uid, attachment.Uid);
            Assert.AreEqual("new name", retrievedAttachment.Name);
            Assert.AreEqual("new folder", retrievedAttachment.Folder);

            await client.RemoveAttachment(TestData.Project2Uid, attachment.Uid);
            Attachment removedAttachment = await client.GetAttachment(TestData.Project2Uid, attachment.Uid);
            Assert.IsTrue(removedAttachment.IsDeleted);
        }

        [Test]
        public async Task GetAttachments()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Attachment> attachments = await client.GetAttachments(TestData.Project1Uid);
            Assert.AreEqual(1, attachments.Data.Count(x => !x.IsDeleted));
            Assert.AreEqual("354371ac-ee8f-bab7-8643-36285a2088a6", attachments.Data[0].Uid);
        }
    }
}