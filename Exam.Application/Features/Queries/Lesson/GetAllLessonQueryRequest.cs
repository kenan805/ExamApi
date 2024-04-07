using Exam.Application.ResponseModels.Pagination;
using Exam.Application.ResponseModels.Results;
using MediatR;

namespace Exam.Application.Features.Queries.Lesson;

public class GetAllLessonQueryRequest : IRequest<IDataResult<List<Domain.Entites.Lesson>>>
{
}

