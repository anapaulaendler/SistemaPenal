using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class StudyService : IStudyService
{
    private readonly IStudyRepository _studyRepository;
    private readonly IPrisonerRepository _prisonerRepository;
    private readonly IUnitOfWork _uow;

    public StudyService(IStudyRepository studyRepository, IPrisonerRepository prisonerRepository, IUnitOfWork uow)
    {
        _studyRepository = studyRepository;
        _prisonerRepository = prisonerRepository;
        _uow = uow;
    }

    public Task CreateStudyActivityAsync(StudyCreateDTO Study)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudyDTO>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudyDTO>> GetStudysAsync()
    {
        throw new NotImplementedException();
    }
}
