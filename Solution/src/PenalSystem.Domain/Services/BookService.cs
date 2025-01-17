using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
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

    public async Task CreateBookActivityAsync(BookCreateDTO book)
    {
        await _uow.BeginTransactionAsync();

        var prisoner = await _prisonerRepository.GetByIdAsync(book.PrisonerId);

        var newBook = new Book()
        {
            PrisonerId = book.PrisonerId,
            Isbn = book.Isbn,
            Prisoner = prisoner,
        };

        await _bookRepository.AddAsync(newBook);
        await _uow.CommitTransactionAsync();

    // public virtual async Task<OperationResult<TCreateDTO>> AddAsync(TCreateDTO itemToCreate, CancellationToken cancellationToken = default(CancellationToken))
    // {
    //     TEntity entity = _mapper.Map<TEntity>(itemToCreate);
    //     OperationResult operationResult = await OnAddingAsync(entity, cancellationToken);
    //     if (!operationResult.IsValid)
    //     {
    //         return operationResult.Cast(itemToCreate);
    //     }

    //     await _repository.AddAsync(entity, cancellationToken);
    //     OperationResult result = await _uow.SaveChangesAsync(cancellationToken);
    //     if (result.IsValid)
    //     {
    //         await OnAddedAsync(new AddedEntityEventArgs<TEntity, object>(entity, itemToCreate), cancellationToken);
    //     }

    //     return result.Cast(itemToCreate);
    // }
    }

    public Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public async Task ReducePrisonerPenalty(Guid prisonerId)
    {
        await _uow.BeginTransactionAsync();

        Prisoner prisoner = await _prisonerRepository.GetByIdAsync(prisonerId);

        prisoner.UpdatedReleaseDate.AddDays(-3);

        await _prisonerRepository.Update(prisoner);
        await _uow.CommitTransactionAsync();
    }
}
