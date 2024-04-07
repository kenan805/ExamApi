using Exam.Application.RequestParameters;
using Exam.Application.Repositories;
using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Features.Queries.Student;
public class StudentQueriesHandler : IRequestHandler<GetAllStudentPaginationQueryRequest, IDataResult<PaginatedList<Domain.Entites.Student>>>,
                                     IRequestHandler<GetAllStudentQueryRequest, IDataResult<List<Domain.Entites.Student>>>
{
    readonly IStudentRepository _studentRepository;

    public StudentQueriesHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IDataResult<PaginatedList<Domain.Entites.Student>>> Handle(GetAllStudentPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAllWithPaginationAsync(pagination: new Pagination(request.PageNumber, request.PageSize));

        return new DataResult<PaginatedList<Domain.Entites.Student>>(students, StatusCodes.Status200OK);
    }

    public async Task<IDataResult<List<Domain.Entites.Student>>> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAll().ToListAsync();

        return new DataResult<List<Domain.Entites.Student>>(students, StatusCodes.Status200OK);
    }
}
