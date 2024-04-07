using Exam.Application.Repositories;
using Exam.Application.ResponseModels.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student;
public class StudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, IResponseResult>
{
    readonly IStudentRepository _studentRepository;

    public StudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IResponseResult> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var isExist = await _studentRepository.ExistAsync(x => x.No == request.No);
        if (isExist)
            return new Result(StatusCodes.Status400BadRequest, $"{request.No} student is exist");

        // Auto mapper istifade edile biler
        await _studentRepository.AddAsync(new()
        {
            Name = request.Name,
            Surname = request.Surname,
            No = request.No,
            Class = request.Class
        });

        await _studentRepository.SaveAsync();
        return new Result(StatusCodes.Status201Created, "Student created");
    }
}