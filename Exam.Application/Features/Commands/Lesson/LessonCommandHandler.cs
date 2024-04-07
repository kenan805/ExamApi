using Exam.Application.Repositories;
using Exam.Application.ResponseModels.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Lesson;
public class LessonCommandHandler : IRequestHandler<CreateLessonCommandRequest, IResponseResult>
{
    readonly ILessonRepository _lessonRepository;

    public LessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<IResponseResult> Handle(CreateLessonCommandRequest request, CancellationToken cancellationToken)
    {
        var isExist = await _lessonRepository.ExistAsync(x => x.Code == request.Code);
        if (isExist)
            return new Result(StatusCodes.Status400BadRequest, $"{request.Code} lesson is exist");

        // Auto mapper istifade edile biler
        await _lessonRepository.AddAsync(new()
        {
            Name = request.Name,
            Code = request.Code,
            Class = request.Class,
            TeacherName = request.TeacherName,
            TeacherSurname = request.TeacherSurname
        });

        await _lessonRepository.SaveAsync();
        return new Result(StatusCodes.Status201Created, "Lesson created");
    }
}