using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum RequestType
    {
        [EnumMember(Value = "all")]
        All = 1,

        [EnumMember(Value = "write")]
        Write = 2
    }
}
