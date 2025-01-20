using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;

namespace PenalSystem.Domain.Interfaces;

public interface IWorkDayService
{
    Task<OperationResult<WorkDay>> CreateWorkDayActivityAsync(WorkDayCreateDTO workDayCreateDTO, CancellationToken cancellation = default);
    Task<List<WorkDayDTO>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
    Task<List<WorkDayDTO>> GetWorkDaysAsync(CancellationToken cancellation = default);
}