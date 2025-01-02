namespace PenalSystem.Domain.Models;

public class Prisoner : Person
{
    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }

    List<Book> Books { get; set; } = [];
    List<Study> Studies { get; set; } = [];
    List<DayOfWork> DaysOfWork { get; set; } = [];
}