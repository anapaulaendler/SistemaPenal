using PenalSystem.Domain.Entities;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class StudyRepository : RepositoryBase<Study>
{
    public StudyRepository(AppDbContext appContext) : base(appContext)
    {
    }
}