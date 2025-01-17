namespace PenalSystem.Domain.DTOs;

public class WorkDayDTO
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public string? Description { get; set; }

    public required PrisonerDTO Prisoner { get; set; }
}

public class WorkDayCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrisonerId { get; set; }
    public string? Description { get; set; }
}