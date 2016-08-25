// <copyright file="RoleTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public async Task GetRoles()
        {
            IPlanGridApi api = PlanGridClient.Create();
            var allRoles = new List<Role>();
            int offset = 0;
            Page<Role> roles = await api.GetRoles(TestData.Project1Uid, offset, 1);
            while (roles.Data.Any())
            {
                offset++;
                allRoles.Add(roles.Data[0]);
                roles = await api.GetRoles(TestData.Project1Uid, offset, 1);
            }
            Assert.AreEqual(3, allRoles.Count);
        }
    }
}