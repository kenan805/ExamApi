using Exam.Application.Features.Commands.Exam;
using Exam.Application.Features.Queries.Exam;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExamsController : ControllerBase
{
    readonly IMediator _mediator;

    public ExamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPagination([FromQuery] GetAllExamPaginationQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExamCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

