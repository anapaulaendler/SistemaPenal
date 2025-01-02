namespace PenalSystem.Domain.Models;

public class Book : Activity
{
    public DateTime CurrentYear { get; set; }
    public required string Isbn { get; set; }
}