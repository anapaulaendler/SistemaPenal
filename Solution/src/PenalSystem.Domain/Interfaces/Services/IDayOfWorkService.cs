using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IDayOfWorkService
{
    Task CreateDayOfWorkActivityAsync(DayOfWorkCreateDTO DayOfWork);
    Task<List<DayOfWorkDTO>> GetDayOfWorkActivitiesByPrisonerIdAsync(Guid prisonerId);
    Task<List<DayOfWorkDTO>> GetDayOfWorksAsync();
}