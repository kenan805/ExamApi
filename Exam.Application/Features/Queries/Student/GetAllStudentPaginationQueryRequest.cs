using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Queries.Student;
public class GetAllStudentPaginationQueryRequest : IRequest<IDataResult<PaginatedList<Domain.Entites.Student>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}