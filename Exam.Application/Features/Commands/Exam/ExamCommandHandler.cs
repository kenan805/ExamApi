using Exam.Application.Repositories;
using Exam.Application.ResponseModels.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam;
public class ExamCommandHandler : IRequestHandler<CreateExamCommandRequest, IResponseResult>
{
    readonly IExamRepository _examRepository;

    public ExamCommandHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<IResponseResult> Handle(CreateExamCommandRequest request, CancellationToken cancellationToken)
    {
        // Auto mapper istifade edile biler
        await _examRepository.AddAsync(new()
        {
            LessonId = request.LessonId,
            StudentId = request.StudentId,
            Date = request.Date,
            Grade = request.Grade
        });

        await _examRepository.SaveAsync();
        return new Result(StatusCodes.Status201Created, "Exam created");
    }
}