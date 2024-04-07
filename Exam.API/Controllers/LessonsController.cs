using Exam.Application.Features.Commands.Lesson;
using Exam.Application.Features.Queries.Lesson;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    readonly IMediator _mediator;

    public LessonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPagination([FromQuery] GetAllLessonPaginationQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllLessonQueryRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLessonCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
