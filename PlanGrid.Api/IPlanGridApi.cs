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
        [Get("/projects")]
        Task<Page<Project>> GetProjects(int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}")]
        Task<Project> GetProject(string projectUid);

        [Post("/projects")]
        Task<Project> CreateProject([Body]ProjectUpdate project);

        [Patch("/projects/{projectUid}")]
        Task<Project> UpdateProject(string projectUid, [Body]ProjectUpdate project);

        [Get("/projects/{projectUid}/comments")]
        Task<Page<Comment>> GetComments(string projectUid, int skip = Page.Skip, int limit = Page.Limit, DateTime? updated_after = null, RecordType[] record_types = null);

        [Get("/projects/{projectUid}/users")]
        Task<Page<User>> GetUsers(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/users/{userUid}")]
        Task<User> GetUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/roles")]
        Task<Page<Role>> GetRoles(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/roles/{roleUid}")]
        Task<Role> GetRole(string projectUid, string roleUid);

        [Post("/projects/{projectUid}/users/invites")]
        Task<User> InviteUser(string projectUid, UserInvitation invitation);

        [Delete("/projects/{projectUid}/users/{userUid}")]
        Task RemoveUser(string projectUid, string userUid);

        [Get("/projects/{projectUid}/issues/{issueUid}")]
        Task<Issue> GetIssue(string projectUid, string issueUid);

        [Get("/projects/{projectUid}/issues")]
        Task<Page<Issue>> GetIssues(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/comments")]
        Task<Page<Comment>> GetIssueComments(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/issues/{issueUid}/photos")]
        Task<Page<Photo>> GetIssuePhotos(string projectUid, string issueUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis")]
        Task<Page<Rfi>> GetRfis(string projectUid, int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/rfis/{rfiUid}")]
        Task<Rfi> GetRfi(string projectUid, string rfiUid);

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

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/snapshots/{snapshotUid}")]
        Task RemoveSnapshotFromRfi(string projectUid, string rfiUid, string snapshotUid);

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/photos/{photoUid}")]
        Task RemovePhotoFromRfi(string projectUid, string rfiUid, string photoUid);

        [Delete("/projects/{projectUid}/rfis/{rfiUid}/attachments/{attachmentUid}")]
        Task RemoveAttachmentFromRfi(string projectUid, string rfiUid, string attachmentUid);

        [Get("/projects/{projectUid}/rfis/{rfiUid}/history")]
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

        [Get("/projects/{projectUid}/attachments")]
        Task<Page<Attachment>> GetAttachments(string projectUid, int skip = Page.Skip, int limit = Page.Limit, string folder = null, DateTime? updated_after = null);

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

        [Get("/projects/{projectUid}/sheets")]
        Task<Page<Sheet>> GetSheets(string projectUid, int skip = Page.Skip, int limit = Page.Limit, DateTime? updated_after = null, string version_set = null);

        [Get("/projects/{projectUid}/snapshots/{snapshotUid}")]
        Task<Snapshot> GetSnapshot(string projectUid, string snapshotUid);

        [Delete("/projects/{projectUid}/snapshots/{snapshotUid}")]
        Task RemoveSnapshot(string projectUid, string snapshotUid);

        [Get("/projects/{projectUid}/sheets/{sheetUid}")]
        Task<Sheet> GetSheet(string projectUid, string sheetUid);

        [Post("/projects/{projectUid}/sheets/uploads")]
        Task<VersionUpload> UploadVersion(string projectUid, [Body]UploadVersionRequest request);

        [Post("/projects/{projectUid}/sheets/uploads/{versionUploadUid}/files/{fileUploadRequestUid}")]
        Task<FileUpload> UploadFileToVersion(string projectUid, string versionUploadUid, string fileUploadRequestUid, [Body]UploadFile file);

        [Post("/projects/{projectUid}/sheets/uploads/files/completions/{uploadToken}")]
        Task CompleteFileUpload(string projectUid, string uploadToken);

        [Post("/projects/{projectUid}/sheets/uploads/{versionUploadUid}/completions")]
        Task CompleteVersionUpload(string projectUid, string versionUploadUid);

        [Post("/projects/{projectUid}/sheets/packets")]
        Task<ShareableObject> CreateSheetPacket(string projectUid, SheetPacketRequest request);

        [Get("/projects/{projectUid}/sheets/packets/{packetUid}")]
        Task<ShareableObject> GetSheetPacket(string projectUid, string packetUid);

        [Get("/rate_limits")]
        Task<Page<RateLimit>> GetRateLimits(int skip = Page.Skip, int limit = Page.Limit);

        [Get("/projects/{projectUid}/snapshots")]
        Task<Page<Snapshot>> GetSnapshots(string projectUid, int skip = Page.Skip, int limit = Page.Limit, DateTime? updated_after = null);

        [Get("/projects/{projectUid}/version_sets")]
        Task<Page<VersionSet>> GetVersionSets(string projectUid, int skip = Page.Skip, int limit = Page.Limit);
    }
}