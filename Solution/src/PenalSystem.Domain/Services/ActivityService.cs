using AutoMapper;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public abstract class ActivityService<TRepository>
{
    protected readonly TRepository _repository;
    protected readonly IPrisonerRepository _prisonerRepository;
    protected readonly IUnitOfWork _uow;
    protected readonly IMapper _mapper;

    protected ActivityService(IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper, TRepository repository)
    {
        _prisonerRepository = prisonerRepository;
        _uow = uow;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task ReducePrisonerPenalty(Guid prisonerId)
    {
        var prisoner = await ValidatePrisonerAsync(prisonerId);

        await _uow.BeginTransactionAsync();
        try
        {
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

    public async Task<Prisoner> ValidatePrisonerAsync(Guid prisonerId)
    {
        var prisoner = await _prisonerRepository.GetByIdAsync(prisonerId);
        if (prisoner == null)
            throw new InvalidOperationException("Prisoner not found.");

        return prisoner;
    }
}