namespace PenalSystem.Domain.DTOs;

public class StudyDTO
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public DateTime Date { get; set; }
    public required string Subject { get; set; }

    public required PrisonerDTO Prisoner { get; set; }
}

public class StudyCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrisonerId { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
    public required string Subject { get; set; }
}