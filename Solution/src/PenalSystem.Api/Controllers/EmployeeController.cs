using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Api.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync(EmployeeCreateDTO employeeCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _employeeService.CreateEmployeeAsync(employeeCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Employee created.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id, cancellation);
        return Ok(employee);
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("cpf/{cpf}")]
    public async Task<IActionResult> GetEmployeeByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        var employee = await _employeeService.GetEmployeeByCpfAsync(cpf, cancellation);
        return Ok(employee);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, EmployeeUpdateDTO updatedEmployee, CancellationToken cancellation = default)
    {
        var result = await _employeeService.UpdateEmployeeAsync(id, updatedEmployee, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Employee updated.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeAsync(Guid id, CancellationToken cancellation = default)
    {
        var result = await _employeeService.DeleteEmployeeAsync(id, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Employee deleted.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet]
    public async Task<IActionResult> GetEmployeesAsync(CancellationToken cancellation = default)
    {
        var employees = await _employeeService.GetEmployeesAsync(cancellation);
        return Ok(employees);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
    {
        try
        {
            var token = await _employeeService.LoginAsync(loginDto);
            return Ok(new { Token = token });
        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }
}