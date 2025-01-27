using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.DTOs;

public class UserLoginDTO
{
    public required string UserEmail { get; set; }
    public required string Password { get; set; }
}

public class LoginResponseDTO
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
}