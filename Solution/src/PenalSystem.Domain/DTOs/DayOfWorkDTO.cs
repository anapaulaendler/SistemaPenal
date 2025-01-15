namespace PenalSystem.Domain.DTOs;

public class DayOfWorkDTO
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public int Counter { get; set; }
    public string? Description { get; set; }

    public required PrisonerDTO Prisoner { get; set; }
}

public class DayOfWorkCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrisonerId { get; set; }
    public int Counter { get; set; }
    public string? Description { get; set; }
}