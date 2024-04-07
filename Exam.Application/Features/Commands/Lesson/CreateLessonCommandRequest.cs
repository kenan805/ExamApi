using Exam.Application.ResponseModels.Results;
using MediatR;

namespace Exam.Application.Features.Commands.Lesson;

public class CreateLessonCommandRequest : IRequest<IResponseResult>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public short Class { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }
}