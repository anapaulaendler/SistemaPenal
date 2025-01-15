using PenalSystem.Domain.Entities;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class DayOfWorkRepository : RepositoryBase<DayOfWork>
{
    public DayOfWorkRepository(AppDbContext appContext) : base(appContext)
    {
    }
}