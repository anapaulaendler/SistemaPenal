using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(Employee user);
}
