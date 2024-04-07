using Exam.Application.ResponseModels.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student;
public class CreateStudentCommandRequest : IRequest<IResponseResult>
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public short Class { get; set; }
}
