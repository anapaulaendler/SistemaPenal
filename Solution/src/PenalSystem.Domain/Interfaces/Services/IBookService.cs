using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IBookService
{
    Task CreateBookActivityAsync(BookCreateDTO book);
    Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId);
    Task<List<BookDTO>> GetBooksAsync();
}