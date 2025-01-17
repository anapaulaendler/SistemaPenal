using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class StudyRepository : RepositoryBase<Study>, IStudyRepository
{
    public StudyRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<List<Study>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        List<Study> studies = [];
        studies = await _dbSet.Where(x => x.PrisonerId == prisonerId).ToListAsync();

        return studies;
    }
}