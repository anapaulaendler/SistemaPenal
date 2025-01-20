using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;

namespace PenalSystem.Domain.Interfaces;

public interface IPrisonerService
{
    Task<OperationResult<Prisoner>> CreatePrisonerAsync(PrisonerCreateDTO prisonerCreateDTO, CancellationToken cancellation = default);
    Task<PrisonerDTO> GetPrisonerByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<PrisonerDTO> GetPrisonerByCpfAsync(string cpf, CancellationToken cancellation = default);
    Task<OperationResult<Prisoner>> UpdatePrisonerAsync(Guid id, PrisonerUpdateDTO updatedPrisoner, CancellationToken cancellation = default);
    Task<OperationResult<Prisoner>> DeletePrisonerAsync(Guid id, CancellationToken cancellation = default); 
    Task<List<PrisonerDTO>> GetPrisonersAsync(CancellationToken cancellation = default);
}