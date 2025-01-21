using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class PrisonerService : IPrisonerService
{
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public PrisonerService(IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper)
    {
        _prisonerRepository = prisonerRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<OperationResult<Prisoner>> CreatePrisonerAsync(PrisonerCreateDTO prisonerCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Prisoner>();

        if (prisonerCreateDTO is null)
        {
            return new OperationResult<Prisoner>(
                new ResultMessage("Invalid prisoner creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = _mapper.Map<Prisoner>(prisonerCreateDTO);

            await _prisonerRepository.AddAsync(prisoner, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<Prisoner> { Value = prisoner };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Prisoner>(
                new ResultMessage($"Failed to create prisoner: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<OperationResult<Prisoner>> DeletePrisonerAsync(Guid id, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Prisoner>();

        var prisonerDTO = GetPrisonerByIdAsync(id);
        var prisoner = _mapper.Map<Prisoner>(prisonerDTO);

        await _uow.BeginTransactionAsync();
        try
        {
            await _prisonerRepository.Delete(prisoner, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<Prisoner> { Value = prisoner };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Prisoner>(
                new ResultMessage($"Failed to delete prisoner: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<PrisonerDTO> GetPrisonerByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("Invalid prisoner CPF.");
        
        var prisoner = await _prisonerRepository.GetPrisonerByCpfAsync(cpf, cancellation);
        var prisonerDTO = _mapper.Map<PrisonerDTO>(prisoner);
        return prisonerDTO;
    }

    public async Task<PrisonerDTO> GetPrisonerByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");
        
        var prisoner = await _prisonerRepository.GetByIdAsync(id, cancellation);
        var prisonerDTO = _mapper.Map<PrisonerDTO>(prisoner);
        return prisonerDTO;
    }

    public async Task<List<PrisonerDTO>> GetPrisonersAsync(CancellationToken cancellation = default)
    {
        var prisoners = await _prisonerRepository.GetAsync(null, cancellation);
        return prisoners.Select(prisoner => _mapper.Map<PrisonerDTO>(prisoner)).ToList();
    }

    public async Task<OperationResult<Prisoner>> UpdatePrisonerAsync(Guid id, PrisonerUpdateDTO updatedPrisoner, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Prisoner>();

        var prisonerDTO = GetPrisonerByIdAsync(id);
        var prisoner = _mapper.Map<Prisoner>(prisonerDTO);

        await _uow.BeginTransactionAsync();

        try
        {
            prisoner.Name = updatedPrisoner.Name;

            await _prisonerRepository.Update(prisoner, cancellation);
            await _uow.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Prisoner>(
                new ResultMessage($"Failed to update prisoner: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }
}
