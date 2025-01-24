using System.Runtime.Serialization;

namespace PenalSystem.Domain.Entities;

public enum Role : byte
{
    [EnumMember(Value = "admin")]
    Admin,
    [EnumMember(Value = "general")]
    General,
}