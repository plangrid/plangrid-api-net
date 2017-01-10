// <copyright file="SnapshotTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class SnapshotTests
    {
        [Test]
        public async Task GetSnapshot()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Snapshot snapshot = await client.GetSnapshot(TestData.Project1Uid, TestData.SnapshotUid);
            Assert.AreEqual("AR.1", snapshot.Title);
        }

        [Test]
        public async Task GetSnapshots()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Snapshot> snapshots = await client.GetSnapshots(TestData.Project1Uid);
            Assert.AreEqual(1, snapshots.Data.Length);
            Assert.AreEqual("AR.1", snapshots.Data[0].Title);
        }

/*
Can't create snapshots via the API so no great way to make a consistently runnable test.
        [Test]
        public async Task RemoveSnapshot()
        {
            IPlanGridApi client = PlanGridClient.Create();
            string snapshotUid = "b15263c7-6a15-48ae-9726-6e4512c9736a";
            Snapshot snapshot = await client.GetSnapshot(TestData.Project2Uid, snapshotUid);
            Assert.IsFalse(snapshot.IsDeleted);
            await client.RemoveSnapshot(TestData.Project2Uid, snapshotUid);
            snapshot = await client.GetSnapshot(TestData.Project2Uid, snapshotUid);
            Assert.IsTrue(snapshot.IsDeleted);
        }
*/
    }
}