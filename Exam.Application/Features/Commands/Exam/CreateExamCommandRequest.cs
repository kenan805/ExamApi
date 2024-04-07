using Exam.Application.ResponseModels.Results;
using Exam.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam;
public class CreateExamCommandRequest : IRequest<IResponseResult>
{
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public DateTime Date { get; set; }
    public short Grade { get; set; }
}
