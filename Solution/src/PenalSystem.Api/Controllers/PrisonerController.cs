using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Api.Controllers;

[ApiController]
[Route("prisoners")]
public class PrisonerController : ControllerBase
{
    private readonly ILogger<PrisonerController> _logger;
    private readonly IPrisonerService _prisonerService;

    public PrisonerController(ILogger<PrisonerController> logger, IPrisonerService prisonerService)
    {
        _logger = logger;
        _prisonerService = prisonerService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreatePrisonerAsync(PrisonerCreateDTO prisonerCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _prisonerService.CreatePrisonerAsync(prisonerCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Prisoner created.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetPrisonerByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        var prisoner = await _prisonerService.GetPrisonerByIdAsync(id, cancellation);
        return Ok(prisoner);
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("cpf/{cpf}")]
    public async Task<IActionResult> GetPrisonerByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        var prisoner = await _prisonerService.GetPrisonerByCpfAsync(cpf, cancellation);
        return Ok(prisoner);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrisonerAsync(Guid id, PrisonerUpdateDTO updatedPrisoner, CancellationToken cancellation = default)
    {
        var result = await _prisonerService.UpdatePrisonerAsync(id, updatedPrisoner, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Prisoner updated.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrisonerAsync(Guid id, CancellationToken cancellation = default)
    {
        var result = await _prisonerService.DeletePrisonerAsync(id, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Prisoner deleted.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet]
    public async Task<IActionResult> GetPrisonersAsync(CancellationToken cancellation = default)
    {
        var prisoners = await _prisonerService.GetPrisonersAsync(cancellation);
        return Ok(prisoners);
    }
}