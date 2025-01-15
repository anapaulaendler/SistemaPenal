using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IStudyService
{
    Task CreateStudyActivityAsync(StudyCreateDTO Study);
    Task<List<StudyDTO>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId);
    Task<List<StudyDTO>> GetStudysAsync();
}