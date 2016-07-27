using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum VersionUploadStatus
    {
        [EnumMember(Value = "incomplete")]
        Incomplete,

        [EnumMember(Value = "complete")]
        Complete,

        [EnumMember(Value = "errored")]
        Errored
    }
}
