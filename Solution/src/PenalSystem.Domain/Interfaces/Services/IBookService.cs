using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;

namespace PenalSystem.Domain.Interfaces;

public interface IBookService
{
    Task<OperationResult<Book>> CreateBookActivityAsync(BookCreateDTO bookCreateDTO, CancellationToken cancellation = default);
    Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
    Task<List<BookDTO>> GetBooksAsync(CancellationToken cancellation = default);
}