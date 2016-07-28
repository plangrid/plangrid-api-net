// <copyright file="PhotoTests.cs" company="PlanGrid, Inc.">
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
    public class PhotoTests
    {
        [Test]
        public async Task UploadPngPhoto()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Stream payload = typeof(PhotoTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.png");
            Photo photo = await client.UploadPngPhoto(TestData.Project2Uid, "test name", payload);

            Assert.AreEqual("test name", photo.Title);
            Assert.AreEqual(TestData.ApiTestsUserUid, photo.CreatedBy.Uid);
            Assert.AreNotEqual(photo.CreatedAt, default(DateTime));

            using (var downloader = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = true }))
            {
                Stream returnedPayload = await downloader.GetStreamAsync(photo.Url);
                payload = typeof(PhotoTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.png");
                var payloadBytes = new MemoryStream();
                await payload.CopyToAsync(payloadBytes);
                var returnedBytes = new MemoryStream();
                await returnedPayload.CopyToAsync(returnedBytes);
                Assert.IsTrue(payloadBytes.ToArray().SequenceEqual(returnedBytes.ToArray()));
            }

            Photo retrievedPhoto = await client.GetPhotoInProject(TestData.Project2Uid, photo.Uid);
            Assert.IsFalse(retrievedPhoto.IsDeleted);
            await client.RemovePhoto(TestData.Project2Uid, photo.Uid);
            Photo removedPhoto = await client.GetPhotoInProject(TestData.Project2Uid, photo.Uid);
            Assert.IsTrue(removedPhoto.IsDeleted);
        }

        [Test]
        public async Task UploadJpegPhoto()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Stream payload = typeof(PhotoTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.jpg");
            Photo photo = await client.UploadPngPhoto(TestData.Project2Uid, "test name", payload);

            Assert.AreEqual("test name", photo.Title);
            Assert.AreEqual(TestData.ApiTestsUserUid, photo.CreatedBy.Uid);
            Assert.AreNotEqual(photo.CreatedAt, default(DateTime));

            using (var downloader = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = true }))
            {
                Stream returnedPayload = await downloader.GetStreamAsync(photo.Url);
                payload = typeof(PhotoTests).Assembly.GetManifestResourceStream("PlanGrid.Api.Tests.TestData.Sample.jpg");
                var payloadBytes = new MemoryStream();
                await payload.CopyToAsync(payloadBytes);
                var returnedBytes = new MemoryStream();
                await returnedPayload.CopyToAsync(returnedBytes);
                Assert.IsTrue(payloadBytes.ToArray().SequenceEqual(returnedBytes.ToArray()));
            }

            Photo retrievedPhoto = await client.GetPhotoInProject(TestData.Project2Uid, photo.Uid);
            Assert.AreEqual("test name", retrievedPhoto.Title);
            await client.UpdatePhoto(TestData.Project2Uid, photo.Uid, new PhotoUpdate { Title = "new title" });
            retrievedPhoto = await client.GetPhotoInProject(TestData.Project2Uid, photo.Uid);
            Assert.AreEqual("new title", retrievedPhoto.Title);

            Assert.IsFalse(retrievedPhoto.IsDeleted);
            await client.RemovePhoto(TestData.Project2Uid, photo.Uid);
            Photo removedPhoto = await client.GetPhotoInProject(TestData.Project2Uid, photo.Uid);
            Assert.IsTrue(removedPhoto.IsDeleted);
        }
    }
}