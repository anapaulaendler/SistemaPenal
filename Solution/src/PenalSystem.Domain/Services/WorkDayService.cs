using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class WorkDayService : ActivityService<IWorkDayRepository>, IWorkDayService
{
    public WorkDayService(IWorkDayRepository repository, IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper)
        : base(prisonerRepository, uow, mapper, repository)
    {
    }

    public async Task<OperationResult<WorkDay>> CreateWorkDayActivityAsync(WorkDayCreateDTO workDayCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<WorkDay>();

        if (workDayCreateDTO is null || workDayCreateDTO.PrisonerId == Guid.Empty)
        {
            return new OperationResult<WorkDay>(
                new ResultMessage("Invalid workDay creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = await ValidatePrisonerAsync(workDayCreateDTO.PrisonerId);

            var workDay = _mapper.Map<WorkDay>(workDayCreateDTO);
            workDay.Prisoner = prisoner;

            await _repository.AddAsync(workDay, cancellation);

            var workDays = await GetWorkDayActivitiesByPrisonerIdAsync(prisoner.Id);

            if (workDays.Any(x => x.Date == DateTime.Today))
            {
                return new OperationResult<WorkDay>(
                    new ResultMessage("Invalid workDay creation request: Today's date has already been logged.", ResultTypes.Error));
            }

            if (workDays.Count() % 3 == 0)
            {
                await ReducePrisonerPenalty(prisoner.Id, -1);
                await _prisonerRepository.Update(prisoner);
            }

            await _uow.CommitTransactionAsync();

            result = new OperationResult<WorkDay> { Value = workDay };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<WorkDay>(
                new ResultMessage($"Failed to create workDay activity: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<List<WorkDayDTO>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        if (prisonerId == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");

        var workDays = await _repository.GetWorkDayActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return workDays.Select(workDay => _mapper.Map<WorkDayDTO>(workDay)).ToList();
    }

    public async Task<List<WorkDayDTO>> GetWorkDaysAsync(CancellationToken cancellation = default)
    {
        var workDays = await _repository.GetAsync(null, cancellation);
        return workDays.Select(workDay => _mapper.Map<WorkDayDTO>(workDay)).ToList();
    }
}