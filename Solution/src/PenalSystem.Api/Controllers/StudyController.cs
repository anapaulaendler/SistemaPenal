using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Api.Controllers;

[ApiController]
[Route("studies")]
public class StudyController : ControllerBase
{
    private readonly ILogger<StudyController> _logger;
    private readonly IStudyService _studyService;

    public StudyController(IStudyService studyService, ILogger<StudyController> logger)
    {
        _studyService = studyService;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateStudyActivityAsync(StudyCreateDTO studyCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _studyService.CreateStudyActivityAsync(studyCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Study activity created.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("{prisonerId}")]
    public async Task<IActionResult> GetStudyActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        var list = await _studyService.GetStudyActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return Ok(list);
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet]
    public async Task<IActionResult> GetStudiesAsync(CancellationToken cancellation = default)
    {
        var list = await _studyService.GetStudiesAsync(cancellation);
        return Ok(list);
    }
}