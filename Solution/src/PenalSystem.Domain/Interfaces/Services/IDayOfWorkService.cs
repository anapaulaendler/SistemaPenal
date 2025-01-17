using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IWorkDayService
{
    Task CreateWorkDayActivityAsync(WorkDayCreateDTO WorkDay);
    Task<List<WorkDayDTO>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId);
    Task<List<WorkDayDTO>> GetWorkDaysAsync();
}