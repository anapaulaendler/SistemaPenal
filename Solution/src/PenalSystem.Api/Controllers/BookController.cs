using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Api.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateBookActivityAsync(BookCreateDTO bookCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _bookService.CreateBookActivityAsync(bookCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Book activity created.");
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet("{prisonerId}")]
    public async Task<IActionResult> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        var list = await _bookService.GetBookActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return Ok(list);
    }

    [Authorize(Roles = "Admin,General")]
    [HttpGet]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellation = default)
    {
        var list = await _bookService.GetBooksAsync(cancellation);
        return Ok(list);
    }
}