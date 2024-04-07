using Exam.Application.RequestParameters;
using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using Exam.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Queries.Lesson;
public class GetAllLessonPaginationQueryRequest : IRequest<IDataResult<PaginatedList<Domain.Entites.Lesson>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}