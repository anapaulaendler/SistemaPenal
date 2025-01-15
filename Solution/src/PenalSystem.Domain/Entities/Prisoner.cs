namespace PenalSystem.Domain.Entities;

public class Prisoner : Person
{
    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }

    public List<Book> Books { get; set; } = [];
    public List<Study> Studies { get; set; } = [];
    public List<DayOfWork> DaysOfWork { get; set; } = [];
}