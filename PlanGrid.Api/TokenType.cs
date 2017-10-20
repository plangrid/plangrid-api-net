using System.Runtime.Serialization;

namespace PlanGrid.Api
{
    public enum TokenType
    {
        Unknown,

        [EnumMember(Value = "Basic")]
        Basic,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}
