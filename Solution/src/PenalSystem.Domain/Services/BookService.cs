using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;

    public BookService(IBookRepository bookRepository, IPrisonerRepository prisonerRepository, IUnitOfWork uow)
    {
        _bookRepository = bookRepository;
        _prisonerRepository = prisonerRepository;
        _uow = uow;
    }

    public Task CreateBookActivityAsync(BookCreateDTO book)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }
}
