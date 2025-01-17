using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class PrisonerService : IPrisonerService
{
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;

    public PrisonerService(IPrisonerRepository prisonerRepository, IUnitOfWork uow)
    {
        _prisonerRepository = prisonerRepository;
        _uow = uow;
    }

    public Task CreatePrisonerAsync(PrisonerCreateDTO prisoner)
    {
        throw new NotImplementedException();
    }

    public Task DeletePrisonerAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PrisonerDTO> GetPrisonerByCpfAsync(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<PrisonerDTO> GetPrisonerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PrisonerDTO>> GetPrisonersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PrisonerDTO> UpdatePrisonerAsync(Guid id, PrisonerUpdateDTO updatedPrisoner)
    {
        throw new NotImplementedException();
    }
}
