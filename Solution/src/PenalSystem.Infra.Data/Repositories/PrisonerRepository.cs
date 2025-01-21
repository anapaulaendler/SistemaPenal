using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class PrisonerRepository : RepositoryBase<Prisoner>, IPrisonerRepository
{
    public PrisonerRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<Prisoner> GetPrisonerByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Cpf == cpf);

        if (entity is null)
        {
            throw new KeyNotFoundException();
        }

        return entity;
    }
}