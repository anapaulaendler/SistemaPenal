using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class WorkDayRepository : RepositoryBase<WorkDay>, IWorkDayRepository
{
    public WorkDayRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<List<WorkDay>> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        List<WorkDay> workDays = [];
        workDays = await _dbSet.Where(x => x.PrisonerId == prisonerId).ToListAsync();

        return workDays;
    }
}