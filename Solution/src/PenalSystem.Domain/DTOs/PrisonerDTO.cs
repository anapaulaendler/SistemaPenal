namespace PenalSystem.Domain.DTOs;

public class PrisonerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }

    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
    public int BookCounter { get; set; }
    public int CurrentYear { get; set; }

    public List<BookDTO> Books { get; set; } = [];
    public List<StudyDTO> Studies { get; set; } = [];
    public List<WorkDayDTO> DaysOfWork { get; set; } = [];
}

public class PrisonerOnlyDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }

    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
}

public class PrisonerCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string Cpf { get; set; }
    public int BookCounter { get; set; } = 0;
    public int CurrentYear { get; set; } = DateTime.Now.Year;

    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
}

public class PrisonerUpdateDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}