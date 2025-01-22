using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Api.Controllers;

[ApiController]
[Route("workDays")]
public class WorkDayController : ControllerBase
{
    private readonly ILogger<WorkDayController> _logger;
    private readonly IWorkDayService _workDayService;

    public WorkDayController(IWorkDayService workDayService, ILogger<WorkDayController> logger)
    {
        _workDayService = workDayService;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateWorkDayActivityAsync(WorkDayCreateDTO workDayCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _workDayService.CreateWorkDayActivityAsync(workDayCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("WorkDay activity created.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("{prisonerId}")]
    public async Task<IActionResult> GetWorkDayActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        var list = await _workDayService.GetWorkDayActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return Ok(list);
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet]
    public async Task<IActionResult> GetWorkDaysAsync(CancellationToken cancellation = default)
    {
        var list = await _workDayService.GetWorkDaysAsync(cancellation);
        return Ok(list);
    }
}