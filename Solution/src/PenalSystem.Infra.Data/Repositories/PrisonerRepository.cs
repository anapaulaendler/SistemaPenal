using PenalSystem.Domain.Entities;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class PrisonerRepository : RepositoryBase<Prisoner>
{
    public PrisonerRepository(AppDbContext appContext) : base(appContext)
    {
    }
}