using System.Runtime.Serialization;

public enum TokenType
{
    [EnumMember(Value = "Basic")]
    Basic,

    [EnumMember(Value = "Bearer")]
    Bearer
}
