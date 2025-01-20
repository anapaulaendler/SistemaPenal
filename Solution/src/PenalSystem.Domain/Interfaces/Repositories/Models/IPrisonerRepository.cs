using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IPrisonerRepository : IRepositoryBase<Prisoner>
{
    Task <Prisoner> GetPrisonerByCpfAsync (string cpf, CancellationToken cancellation = default);
}