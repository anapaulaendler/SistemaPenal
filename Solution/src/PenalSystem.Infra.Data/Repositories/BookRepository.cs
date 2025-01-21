using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<List<Book>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        List<Book> books = [];
        books = await _dbSet.Where(x => x.PrisonerId == prisonerId).ToListAsync();

        return books;
    }
}