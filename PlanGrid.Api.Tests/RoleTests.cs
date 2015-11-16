// <copyright file="RoleTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class RoleTests
    {
        [Test]
        public async Task GetRole()
        {
            IPlanGridApi api = PlanGridClient.Create();
            Role role = await api.GetRole(TestData.Project1Uid, TestData.AdminRoleId);
            Assert.AreEqual("Admin", role.Label);
        }
    }
}