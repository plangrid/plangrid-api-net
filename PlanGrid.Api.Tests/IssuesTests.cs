// <copyright file="IssuesTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class IssuesTests
    {
        [Test]
        public async Task GetIssues()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Issue> page = await client.GetIssues(TestData.Project1Uid);
            Assert.AreEqual(1, page.TotalCount);
            Issue issue = page.Data[0];
            await ValidateIssue(issue, client);
        }

        [Test]
        public async Task GetIssue()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Issue issue = await client.GetIssue(TestData.Project1Uid, "45460feb-2c09-663f-352f-d053444b138a");
            await ValidateIssue(issue, client);
        }

        private static async Task ValidateIssue(Issue issue, IPlanGridApi client)
        {
            Assert.IsFalse(issue.IsDeleted);
            Assert.AreEqual(TestData.ApiTestsUserEmail, issue.AssignedTo.Single().Email);
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:13:49"), issue.CreatedAt);
            Assert.AreEqual(TestData.ApiTestsUserEmail, issue.CreatedBy.Email);
            Assert.AreEqual("Test Description", issue.Description);
            Assert.AreEqual(1, issue.Number);
            Assert.AreEqual("Test Room", issue.Room);
            Assert.AreEqual(IssueStatus.Open, issue.Status);
            Assert.AreEqual(TestData.ApiTestsUserEmail, issue.UpdatedBy.Email);
            Assert.IsFalse(string.IsNullOrEmpty(issue.Uid));
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:13:50"), issue.UpdatedAt);
            Assert.IsFalse(issue.IsDeleted);
            Assert.AreEqual("#FF0000", issue.CurrentAnnotation.Color);
            Assert.IsFalse(issue.CurrentAnnotation.IsDeleted);
            Assert.AreEqual("AC", issue.CurrentAnnotation.Stamp);
            Assert.IsFalse(string.IsNullOrEmpty(issue.CurrentAnnotation.Uid));
            Assert.AreEqual(AnnotationVisibility.Master, issue.CurrentAnnotation.Visibility);

            Sheet sheet = await client.Resolve(issue.CurrentAnnotation.Sheet);
            Assert.AreEqual("AR.1", sheet.Name);
            Assert.IsFalse(sheet.IsDeleted);
            Assert.IsFalse(string.IsNullOrEmpty(sheet.Uid));
            Assert.AreEqual("Initial Set", sheet.VersionName);

            Page<Photo> photos = await client.Resolve(issue.Photos);
            Assert.AreEqual(1, photos.TotalCount);
            Assert.AreEqual(1, issue.Photos.TotalCount);
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:32:43"), photos.Data[0].CreatedAt);
            Assert.AreEqual(TestData.ApiTestsUserEmail, photos.Data[0].CreatedBy.Email);
            Assert.AreEqual("Galaxy", photos.Data[0].Title);
            Assert.AreEqual(TestData.PhotoUrl, photos.Data[0].Url);
            Assert.IsFalse(string.IsNullOrEmpty(photos.Data[0].Uid));
            Assert.IsFalse(photos.Data[0].IsDeleted);

            Page<Comment> comments = await client.Resolve(issue.Comments);
            Assert.AreEqual(1, comments.TotalCount);
            Assert.AreEqual(1, issue.Comments.TotalCount);
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:35:21.698"), comments.Data[0].CreatedAt);
            Assert.AreEqual(TestData.ApiTestsUserEmail, comments.Data[0].CreatedBy.Email);
            Assert.AreEqual("Test Comment", comments.Data[0].Text);
            Assert.IsFalse(string.IsNullOrEmpty(comments.Data[0].Uid));
        }

        [Test]
        public async Task GetIssueComments()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Comment> comments = await client.GetIssueComments(TestData.Project1Uid, TestData.Project1Issue1Uid);
            Assert.AreEqual(1, comments.TotalCount);
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:35:21.698"), comments.Data[0].CreatedAt);
            Assert.AreEqual(TestData.ApiTestsUserEmail, comments.Data[0].CreatedBy.Email);
            Assert.AreEqual("Test Comment", comments.Data[0].Text);
            Assert.IsFalse(string.IsNullOrEmpty(comments.Data[0].Uid));
        }

        [Test]
        public async Task GetIssuePhotos()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Photo> photos = await client.GetIssuePhotos(TestData.Project1Uid, TestData.Project1Issue1Uid);
            Assert.AreEqual(1, photos.TotalCount);
            Assert.AreEqual(DateTime.Parse("11/16/2015 18:32:43"), photos.Data[0].CreatedAt);
            Assert.AreEqual(TestData.ApiTestsUserEmail, photos.Data[0].CreatedBy.Email);
            Assert.AreEqual("Galaxy", photos.Data[0].Title);
            Assert.AreEqual(TestData.PhotoUrl, photos.Data[0].Url);
            Assert.IsFalse(string.IsNullOrEmpty(photos.Data[0].Uid));
            Assert.IsFalse(photos.Data[0].IsDeleted);
        }
    }
}