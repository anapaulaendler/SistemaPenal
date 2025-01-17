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
}