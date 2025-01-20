using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;

namespace PenalSystem.Domain.Interfaces;

public interface IStudyService
{
    Task<OperationResult<Study>> CreateStudyActivityAsync(StudyCreateDTO studyCreateDTO, CancellationToken cancellation = default);
    Task<List<StudyDTO>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
    Task<List<StudyDTO>> GetStudysAsync(CancellationToken cancellation = default);
}