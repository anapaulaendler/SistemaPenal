using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class BookService : ActivityService<IBookRepository>, IBookService
{
    public BookService(IBookRepository repository, IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper)
        : base(prisonerRepository, uow, mapper, repository)
    {
    }

    public async Task<OperationResult<Book>> CreateBookActivityAsync(BookCreateDTO bookCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Book>();

        if (bookCreateDTO is null || bookCreateDTO.PrisonerId == Guid.Empty)
        {
            return new OperationResult<Book>(
                new ResultMessage("Invalid book creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = await ValidatePrisonerAsync(bookCreateDTO.PrisonerId);

            var book = _mapper.Map<Book>(bookCreateDTO);
            book.Prisoner = prisoner;

            await _repository.AddAsync(book, cancellation);

            await ReducePrisonerPenalty(prisoner.Id, -3);
            await _prisonerRepository.Update(prisoner);
            
            await _uow.CommitTransactionAsync();

            result = new OperationResult<Book> { Value = book };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Book>(
                new ResultMessage($"Failed to create book activity: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<List<BookDTO>> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        if (prisonerId == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");

        var books = await _repository.GetBookActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
    }

    public async Task<List<BookDTO>> GetBooksAsync(CancellationToken cancellation = default)
    {
        var books = await _repository.GetAsync(null, cancellation);
        return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
    }
}