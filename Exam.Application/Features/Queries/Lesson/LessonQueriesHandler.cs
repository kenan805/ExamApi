using Exam.Application.Repositories;
using Exam.Application.RequestParameters;
using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Queries.Lesson;
public class LessonQueriesHandler : IRequestHandler<GetAllLessonPaginationQueryRequest, IDataResult<PaginatedList<Domain.Entites.Lesson>>>,
                                    IRequestHandler<GetAllLessonQueryRequest, IDataResult<List<Domain.Entites.Lesson>>>
{
    readonly ILessonRepository _lessonRepository;

    public LessonQueriesHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<IDataResult<PaginatedList<Domain.Entites.Lesson>>> Handle(GetAllLessonPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        var lessons = await _lessonRepository.GetAllWithPaginationAsync(pagination: new Pagination(request.PageNumber, request.PageSize));

        return new DataResult<PaginatedList<Domain.Entites.Lesson>>(lessons, StatusCodes.Status200OK);
    }

    public async Task<IDataResult<List<Domain.Entites.Lesson>>> Handle(GetAllLessonQueryRequest request, CancellationToken cancellationToken)
    {
        var lessons = await _lessonRepository.GetAll().ToListAsync();

        return new DataResult<List<Domain.Entites.Lesson>>(lessons, StatusCodes.Status200OK);
    }
}
