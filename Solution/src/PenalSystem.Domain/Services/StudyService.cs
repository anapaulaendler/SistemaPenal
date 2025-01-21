using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class StudyService : ActivityService<IStudyRepository>, IStudyService
{
    public StudyService(IStudyRepository repository, IPrisonerRepository prisonerRepository, IUnitOfWork uow, IMapper mapper)
        : base(prisonerRepository, uow, mapper, repository)
    {
    }

    public async Task<OperationResult<Study>> CreateStudyActivityAsync(StudyCreateDTO studyCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Study>();

        if (studyCreateDTO is null || studyCreateDTO.PrisonerId == Guid.Empty)
        {
            return new OperationResult<Study>(
                new ResultMessage("Invalid study creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = await ValidatePrisonerAsync(studyCreateDTO.PrisonerId);

            var study = _mapper.Map<Study>(studyCreateDTO);
            study.Prisoner = prisoner;

            await _repository.AddAsync(study, cancellation);

            var studies = await GetStudyActivitiesByPrisonerIdAsync(prisoner.Id);

            if (studies.Count() % 3 == 0)
            {
                await ReducePrisonerPenalty(prisoner.Id, -1);
                await _prisonerRepository.Update(prisoner);
            }

            await _uow.CommitTransactionAsync();

            result = new OperationResult<Study> { Value = study };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Study>(
                new ResultMessage($"Failed to create study activity: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<List<StudyDTO>> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        if (prisonerId == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");

        var studys = await _repository.GetStudyActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return studys.Select(study => _mapper.Map<StudyDTO>(study)).ToList();
    }

    public async Task<List<StudyDTO>> GetStudysAsync(CancellationToken cancellation = default)
    {
        var studys = await _repository.GetAsync(null, cancellation);
        return studys.Select(study => _mapper.Map<StudyDTO>(study)).ToList();
    }
}