using Exam.Application.DTOs.Exams;
using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Queries.Exam;
public class GetAllExamPaginationQueryRequest : IRequest<IDataResult<PaginatedList<GetExamDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}