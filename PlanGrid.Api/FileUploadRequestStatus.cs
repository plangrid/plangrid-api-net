using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum FileUploadRequestStatus
    {
        [EnumMember(Value = "issued")]
        Issued,

        [EnumMember(Value = "consumed")]
        Consumed
    }
}
