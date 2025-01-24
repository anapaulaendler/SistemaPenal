using System.Text.Json.Serialization;

namespace PenalSystem.Domain.Entities;

public class Employee : Person
{
    public required string Email { get; set; }
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role { get; set; }
    public required string Password { get; set; }
}