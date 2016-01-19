// <copyright file="ProjectUserTests.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public async Task GetUsers()
        {
            IPlanGridApi api = PlanGridClient.Create();
            Page<User> users = await api.GetUsers(TestData.Project1Uid);
            Assert.AreEqual(3, users.Data.Length);

            User user = users.Data[2];
            Assert.AreEqual(TestData.ApiTestsUserEmail, user.Email);
            Assert.IsTrue(!string.IsNullOrEmpty(user.Uid));

            Role role = await api.Resolve(user.Role);
            Assert.AreEqual("Admin", role.Label);
        }

        [Test]
        public async Task GetUser()
        {
            IPlanGridApi api = PlanGridClient.Create();
            User user = await api.GetUser(TestData.Project1Uid, TestData.ApiTestsUserUid);

            Assert.AreEqual(TestData.ApiTestsUserEmail, user.Email);
            Assert.IsTrue(!string.IsNullOrEmpty(user.Uid));

            Role role = await api.Resolve(user.Role);
            Assert.AreEqual("Admin", role.Label);
        }

        [Test]
        public async Task InviteAndRemoveUser()
        {
            IPlanGridApi api = PlanGridClient.Create();
            User invitedUser = await api.InviteUser(TestData.Project1Uid, new UserInvitation
            {
                Email = TestData.InvitedUserEmail,
                RoleUid = TestData.AdminRoleId
            });
            Assert.AreEqual(TestData.InvitedUserEmail, invitedUser.Email);
            Assert.IsFalse(invitedUser.IsRemoved);
            Assert.AreEqual(TestData.AdminRoleId, invitedUser.Role.Uid);

            User removedUser = await api.RemoveUser(TestData.Project1Uid, invitedUser.Uid);
            Assert.IsTrue(removedUser.IsRemoved);
            Assert.AreEqual(invitedUser.Uid, removedUser.Uid);
        }
    }
}