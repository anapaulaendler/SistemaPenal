using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _prisonerRepository = prisonerRepository;
        _uow = uow;
        _mapper = mapper;
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
            var prisoner = await _prisonerRepository.GetByIdAsync(bookCreateDTO.PrisonerId);
            if (prisoner is null)
            {
                return new OperationResult<Book>(
                    new ResultMessage("Prisoner not found.", ResultTypes.Error));
            }

            var book = _mapper.Map<Book>(bookCreateDTO);
            book.Prisoner = prisoner;

            await _bookRepository.AddAsync(book, cancellation);
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

        var books = await _bookRepository.GetBooksByPrisonerIdAsync(prisonerId, cancellation);
        // implement later!!!!!!!!!!!!!!!!!!
        return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
    }

    public async Task<List<BookDTO>> GetBooksAsync(CancellationToken cancellation = default)
    {
        var books = await _bookRepository.GetAsync();
        // var books = await _bookRepository.GetAsync(cancellation);
        return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
    }

    public async Task ReducePrisonerPenalty(Guid prisonerId)
    {
        if (prisonerId == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = await _prisonerRepository.GetByIdAsync(prisonerId);
            if (prisoner == null)
                throw new InvalidOperationException("Prisoner not found.");

            prisoner.UpdatedReleaseDate = prisoner.UpdatedReleaseDate.AddDays(-3);

            await _prisonerRepository.Update(prisoner);
            await _uow.CommitTransactionAsync();
        }
        catch
        {
            await _uow.RollbackTransactionAsync();
            throw;
        }
    }

    private async Task ValidatePrisonerAsync(Guid prisonerId)
    {
        var prisoner = await _prisonerRepository.GetByIdAsync(prisonerId);
        if (prisoner == null)
            throw new InvalidOperationException("Prisoner not found.");
    }
}