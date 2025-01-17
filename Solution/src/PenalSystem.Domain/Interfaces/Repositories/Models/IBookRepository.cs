using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId);
}