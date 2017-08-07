// <copyright file="TestData.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;

namespace PlanGrid.Api.Tests
{
    public static class TestData
    {
        public const string Project1Uid = "d1e8e222-b05b-e750-74e4-d19b92c25506";
        public const string Project1Issue1Uid = "45460feb-2c09-663f-352f-d053444b138a";
        public const string Project1Rfi1Uid = "a3d1c702-3bed-c496-8cf0-6535218cce00";
        public const string Project1VersionSet1Uid = "f160b073-c249-4246-8e77-c53ec3c272e0";
        public const string Project2Uid = "269ad633-0688-395e-5c30-cc685e0ce964";
        public const string Project2DraftRfiStatusUid = "00a8b880";
        public const string Project2OpenRfiStatusUid = "bcadf1c9";
        public const string Project2PhotoUid = "6f976878-d243-c787-dfda-0290b7761968";
        public const string PhotoUrl = "https://photo-assets-test.plangrid.com/5a16f6d9-8006-ea7d-12ee-76c778b7094f.jpg";
        public const string ApiTestsUserEmail = "kirk+apitests@plangrid.com";
        public const string ApiTestsUserUid = "5644e9acf0cb79476f1d48ee";
        public const string ApiTestsUser2Email = "kirk+apitests2@plangrid.com";
        public const string ApiTestsUser2Uid = "569e7cf89a5775ea157c9032";
        public const string InvitedUserEmail = "kirk+apiinvitee@plangrid.com";
        public const string AdminRoleId = "9d139e64-cac9-4f23-b4d5-9fd3688b498e";
        public const string SnapshotUid = "59F884BA-1CDC-459C-B302-3532E13DBB9A";
        public const string VersionSet1Name = "Initial Set";
        public static DateTime VersionSet1PublishDate => new DateTime(2015, 11, 12);
        public const string NotFoundUid = "00000000-0000-0000-0000-000000000000";

        public static readonly string RateLimitedPlanGridApiKey = Environment.GetEnvironmentVariable("PLANGRIDAPIKEY_LIMITED");

    }
}