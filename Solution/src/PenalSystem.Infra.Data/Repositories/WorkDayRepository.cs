using PenalSystem.Domain.Entities;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class WorkDayRepository : RepositoryBase<WorkDay>
{
    public WorkDayRepository(AppDbContext appContext) : base(appContext)
    {
    }
}