using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IStudyRepository : IRepositoryBase<Study>
{
    Task<List<StudyDTO>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId);
}