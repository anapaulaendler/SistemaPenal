using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Entities;

public abstract class Activity : IEntity
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }

    public required Prisoner Prisoner { get; set; }
}