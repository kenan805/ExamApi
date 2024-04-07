using Exam.Application.ResponseModels.Results;
using MediatR;

namespace Exam.Application.Features.Queries.Student;

public class GetAllStudentQueryRequest : IRequest<IDataResult<List<Domain.Entites.Student>>>
{
}
