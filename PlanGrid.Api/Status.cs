using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum Status
    {
        [EnumMember(Value = "incomplete")]
        Incomplete,

        [EnumMember(Value = "complete")]
        Complete,

        [EnumMember(Value = "errored")]
        Errored
    }
}
