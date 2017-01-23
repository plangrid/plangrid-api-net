// <copyright file="AnnotationTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class AnnotationTests
    {
        [Test]
        public async Task GetAnnotations()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Annotation> page = await client.GetAnnotations(TestData.Project1Uid, updated_after: new DateTime(2015, 11, 15));
            Annotation annotation = page.Data.Single();

            Assert.AreEqual("#FF0000", annotation.Color);
            Assert.IsFalse(annotation.IsDeleted);
            Assert.AreEqual("AC", annotation.Stamp);
            Assert.IsFalse(string.IsNullOrEmpty(annotation.Uid));
            Assert.AreEqual(AnnotationVisibility.Master, annotation.Visibility);
        }
    }
}