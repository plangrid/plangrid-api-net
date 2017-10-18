using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum TokenType
    {
        [EnumMember(Value = "Basic")]
        Basic,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}
