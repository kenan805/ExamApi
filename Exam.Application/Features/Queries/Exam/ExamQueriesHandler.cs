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
using Exam.Application.DTOs.Exams;
using AutoMapper;

namespace Exam.Application.Features.Queries.Exam;
public class ExamQueriesHandler : IRequestHandler<GetAllExamPaginationQueryRequest, IDataResult<PaginatedList<GetExamDto>>>
{
    readonly IExamRepository _examRepository;
    readonly IMapper _mapper;

    public ExamQueriesHandler(IExamRepository examRepository, IMapper mapper)
    {
        _examRepository = examRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<PaginatedList<GetExamDto>>> Handle(GetAllExamPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        var exams = await _examRepository.GetAllWithPaginationAsync(
            tracking: false,
            pagination: new Pagination(request.PageNumber, request.PageSize),
            method: exam => !exam.IsDeleted,
            orderBy: exam => exam.OrderByDescending(exam => exam.Date),
            exam => exam.Lesson, exam => exam.Student);

        var examsDto = _mapper.Map<PaginatedList<GetExamDto>>(exams);

        return new DataResult<PaginatedList<GetExamDto>>(examsDto, StatusCodes.Status200OK);
    }
}

