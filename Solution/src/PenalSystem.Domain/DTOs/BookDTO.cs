namespace PenalSystem.Domain.DTOs;

public class BookDTO
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public required string Isbn { get; set; }

    public required PrisonerDTO Prisoner { get; set; }
}

public class BookCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrisonerId { get; set; }
    public required string Isbn { get; set; }
}