using System.Text.Json.Serialization;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.DTOs;

public class EmployeeDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }

    public required string Email { get; set; }
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role { get; set; }
    public required string Password { get; set; }
}

public class EmployeeCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role { get; set; }
    public required string Password { get; set; }
}

public class EmployeeUpdateDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role { get; set; }
    public required string Password { get; set; }
}
