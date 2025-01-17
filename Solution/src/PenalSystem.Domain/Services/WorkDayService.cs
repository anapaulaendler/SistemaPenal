using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class WorkDayService : IWorkDayService
{
    private readonly IWorkDayRepository _workDayRepository;
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;

    public WorkDayService(IWorkDayRepository workDayRepository, IPrisonerRepository prisonerRepository, IUnitOfWork uow)
    {
        _workDayRepository = workDayRepository;
        _prisonerRepository = prisonerRepository;
        _uow = uow;
    }

    public Task CreateWorkDayActivityAsync(WorkDayCreateDTO WorkDay)
    {
        throw new NotImplementedException();
    }

    public Task<List<WorkDayDTO>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<WorkDayDTO>> GetWorkDaysAsync()
    {
        throw new NotImplementedException();
    }
}
