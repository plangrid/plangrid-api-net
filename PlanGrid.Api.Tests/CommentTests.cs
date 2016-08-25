// <copyright file="CommentTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class CommentTests
    {
        [Test]
        public async Task GetComments()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Comment> comments = await client.GetComments(TestData.Project1Uid);
            Assert.AreEqual(2, comments.TotalCount);
        }
    }
}