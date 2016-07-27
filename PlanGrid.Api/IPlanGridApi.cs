// <copyright file="IPlanGridApi.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Refit;

namespace PlanGrid.Api
{
    public interface IPlanGridApi : IDisposable
    {
        [Get("/projects?skip={skip}&limit={limit}")]
        Task<Page<Project>> GetProjects(int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}")]
        Task<Project> GetProject(string projectUid);

        [Post("/projects")]
        Task<Project> CreateProject([Body]ProjectUpdate project);

        [Patch("/projects/{projectUid}")]
        Task<Project> UpdateProject(string projectUid, [Body]ProjectUpdate project);

        [Get("/projects/{projectUid}/users?skip={skip}&limit={limit}")]
        Task<Page<User>> GetUsers(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/users/{userUid}")]
        Task<User> GetUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/roles?skip={skip}&limit={limit}")]
        Task<Page<Role>> GetRoles(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/roles/{roleUid}")]
        Task<Role> GetRole(string projectUid, string roleUid);

        [Post("/projects/{projectUid}/users/invites")]
        Task<User> InviteUser(string projectUid, UserInvitation invitation);

        [Delete("/projects/{projectUid}/users/{userUid}")]
        Task RemoveUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/issues?skip={skip}&limit={limit}")]
        Task<Page<Issue>> GetIssues(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/comments?skip={skip}&limit={limit}")]
        Task<Page<Comment>> GetIssueComments(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/photos?skip={skip}&limit={limit}")]
        Task<Page<Photo>> GetIssuePhotos(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis?skip={skip}&limit={limit}")]
        Task<Page<Rfi>> GetRfis(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}")]
        Task<Rfi> GetRfi(string projectUid, string rfiUid);

        [Get("/projects/{projectUid}/rfis/statuses?skip={skip}&limit={limit}")]
        Task<Page<RfiStatus>> GetRfiStatuses(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/attachments?skip={skip}&limit={limit}")]
        Task<Page<Attachment>> GetRfiAttachments(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/comments?skip={skip}&limit={limit}")]
        Task<Page<Comment>> GetRfiComments(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/photos?skip={skip}&limit={limit}")]
        Task<Page<Photo>> GetRfiPhotos(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/snapshots?skip={skip}&limit={limit}")]
        Task<Page<Snapshot>> GetRfiSnapshots(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/snapshots/{snapshotUid}")]
        Task RemoveSnapshotFromRfi(string projectUid, string rfiUid, string snapshotUid);

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/photos/{photoUid}")]
        Task RemovePhotoFromRfi(string projectUid, string rfiUid, string photoUid);

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/attachments/{attachmentUid}")]
        Task RemoveAttachmentFromRfi(string projectUid, string rfiUid, string attachmentUid);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/history?skip={skip}&limit={limit}")]
        Task<Page<RfiChange>> GetRfiHistory(string projectUid, string rfiUid, int skip = Page.Skip, int limit = Page.Limit);

        [Patch("/projects/{projectUid}/rfis/statuses/{statusUid}")]
        Task<RfiStatus> UpdateRfiStatus(string projectUid, string statusUid, [Body]RfiStatusUpdate statusUpdate);

        [Post("/projects/{projectUid}/rfis")]
        Task<Rfi> CreateRfi(string projectUid, [Body]RfiUpsert rfi);

        [Patch("/projects/{projectUid}/rfis/{rfiUid}")]
        Task<Rfi> UpdateRfi(string projectUid, string rfiUid, [Body]RfiUpsert rfi);

        [Post("/projects/{projectUid}/attachments/uploads")]
        Task<FileUpload> CreateAttachmentUploadRequest(string projectUid, [Body]AttachmentUpload upload);

        [Delete("/projects/{projectUid}/attachments/{attachmentUid}")]
        Task RemoveAttachment(string projectUid, string attachmentUid);

        [Patch("/projects/{projectUid}/attachments/{attachmentUid}")]
        Task<Attachment> UpdateAttachment(string projectUid, string attachmentUid, [Body] AttachmentUpdate attachment);

        [Get("/projects/{projectUid}/attachments?skip={skip}&limit={limit}&folder={folder}&updated_after={updatedAfter}")]
        Task<Page<Attachment>> GetAttachments(string projectUid, int skip = Page.Skip, int limit = Page.Limit, string folder = null, DateTime? updatedAfter = null);

        [Get("/projects/{projectUid}/attachments/{attachmentUid}")]
        Task<Attachment> GetAttachment(string projectUid, string attachmentUid);

        [Post("/projects/{projectUid}/photos/uploads")]
        Task<FileUpload> CreatePhotoUploadRequest(string projectUid, [Body]PhotoUpload upload);

        [Post("/projects/{projectUid}/rfis/{rfiUid}/attachments")]
        Task ReferenceAttachmentFromRfi(string projectUid, string rfiUid, [Body]AttachmentReference attachmentReference);

        [Post("/projects/{projectUid}/rfis/{rfiUid}/photos")]
        Task ReferencePhotoFromRfi(string projectUid, string rfiUid, [Body]PhotoReference photoReference);

        [Get("/projects/{projectUid}/photos/{photoUid}")]
        Task<Photo> GetPhotoInProject(string projectUid, string photoUid);

        [Delete("/projects/{projectUid}/photos/{photoUid}")]
        Task RemovePhoto(string projectUid, string photoUid);

        [Patch("/projects/{projectUid}/photos/{photoUid}")]
        Task<Photo> UpdatePhoto(string projectUid, string photoUid, [Body]PhotoUpdate photo);

        [Get("/projects/{projectUid}/snapshots/{snapshotUid}")]
        Task<Snapshot> GetSnapshot(string projectUid, string snapshotUid);

        [Delete("/projects/{projectUid}/snapshots/{snapshotUid}")]
        Task RemoveSnapshot(string projectUid, string snapshotUid);

        [Get("/projects/{projectUid}/sheets?skip={skip}&limit={limit}&updated_after={updatedAfter}")]
        Task<Page<Sheet>> GetSheets(string projectUid, int skip = Page.Skip, int limit = Page.Limit, DateTime? updatedAfter = null);

        [Get("/projects/{projectUid}/sheets/{sheetUid}")]
        Task<Sheet> GetSheet(string projectUid, string sheetUid);

        [Post("/projects/{projectUid}/sheets/uploads")]
        Task<VersionUpload> UploadVersion(string projectUid, [Body]UploadVersionRequest request);

        [Post("/projects/{projectUid}/sheets/uploads/{versionUploadUid}")]
        Task<FileUpload> UploadFileToVersion(string projectUid, string versionUploadUid);

        [Post("/projects/{projectUid}/sheets/uploads/files/completions/{uploadToken}")]
        Task CompleteFileUpload(string projectUid, string uploadToken);

        [Post("/projects/{projectUid}/sheets/uploads/{versionUploadUid}/completions")]
        Task CompleteVersionUpload(string projectUid, string versionUploadUid);

        [Post("/projects/{projectUid}/sheets/packets")]
        Task<ShareableObject> CreateSheetPacket(string projectUid);

        [Post("/projects/{projectUid}/sheets/packets/{packetUid}")]
        Task<ShareableObject> GetSheetPacket(string projectUid, string packetUid);
    }
}