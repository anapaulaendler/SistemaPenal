using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IPrisonerRepository : IRepositoryBase<Prisoner>
{
    Task ReducePenaltyAsync (Guid id);
    Task <PrisonerDTO> GetPrisonerByCpfAsync (string cpf);
}