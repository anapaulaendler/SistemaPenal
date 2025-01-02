namespace PenalSystem.Domain.Models;

public class Employee : Person
{
    public required string Email { get; set; }
    public Role Role { get; set; }
    public required string Password { get; set; }
}