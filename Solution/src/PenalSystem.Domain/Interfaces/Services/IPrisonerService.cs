using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IPrisonerService
{
    Task CreatePrisonerAsync(PrisonerCreateDTO prisoner);
    Task<PrisonerDTO> GetPrisonerByIdAsync(Guid id);
    Task<PrisonerDTO> GetPrisonerByCpfAsync(string cpf);
    Task<PrisonerDTO> UpdatePrisonerAsync(Guid id, PrisonerUpdateDTO updatedPrisoner);
    Task DeletePrisonerAsync(Guid id); 
    Task<List<PrisonerDTO>> GetPrisonersAsync();
}