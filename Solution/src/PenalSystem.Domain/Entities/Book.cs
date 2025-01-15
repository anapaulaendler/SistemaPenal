namespace PenalSystem.Domain.Entities;

public class Book : Activity
{
    public DateTime CurrentYear { get; set; }
    public required string Isbn { get; set; }
}