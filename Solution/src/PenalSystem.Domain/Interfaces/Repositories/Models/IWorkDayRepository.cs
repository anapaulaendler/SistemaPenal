using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IWorkDayRepository : IRepositoryBase<WorkDay>
{
    Task<List<WorkDay>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
}