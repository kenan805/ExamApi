using Exam.Application.Features.Commands.Lesson;
using Exam.Application.Features.Commands.Student;
using Exam.Application.Features.Queries.Lesson;
using Exam.Application.Features.Queries.Student;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("pagination")]
    public async Task<IActionResult> GetPagination([FromQuery] GetAllStudentPaginationQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllStudentQueryRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
