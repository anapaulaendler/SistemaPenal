using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Models;

public abstract class Person : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }
}