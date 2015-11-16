// <copyright file="IPlanGridApi.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2015 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Refit;

namespace PlanGrid.Api
{
    public interface IPlanGridApi : IDisposable
    {
        [Get("/projects")]
        Task<Page<Project>> GetProjects(int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}")]
        Task<Project> GetProject(string projectUid);

        [Post("/projects")]
        Task<Project> CreateProject([Body]ProjectUpdate project);

        [Get("/projects/{projectUid}/users")]
        Task<Page<User>> GetUsers(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/users/{userUid}")]
        Task<User> GetUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/roles/{roleUid}")]
        Task<Role> GetRole(string projectUid, string roleUid);

        [Post("/projects/{projectUid}/users/invites")]
        Task<User> InviteUser(string projectUid, UserInvitation invitation);

        [Delete("/projects/{projectUid}/users/{userUid}")]
        Task<User> RemoveUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/issues")]
        Task<Page<Issue>> GetIssues(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/comments")]
        Task<Page<Comment>> GetIssueComments(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/photos")]
        Task<Page<Photo>> GetIssuePhotos(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis")]
        Task<Page<Rfi>> GetRfis(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/statuses")]
        Task<Page<RfiStatus>> GetRfiStatuses(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/attachments")]
        Task<Page<Attachment>> GetRfiAttachments(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/comments")]
        Task<Page<Comment>> GetRfiComments(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/photos")]
        Task<Page<Photo>> GetRfiPhotos(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/snapshots")]
        Task<Page<Snapshot>> GetRfiSnapshots(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);
    }
}