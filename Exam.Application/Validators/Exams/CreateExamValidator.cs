using Exam.Application.Features.Commands.Exam;
using Exam.Application.Features.Commands.Lesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Exams;
public class CreateExamValidator : AbstractValidator<CreateExamCommandRequest>
{
    public CreateExamValidator()
    {
        RuleFor(e => e.Date)
            .NotEmpty()
                .WithMessage("Enter exam date");

        RuleFor(e => e.Grade)
            .InclusiveBetween((short)1, (short)9)
                .WithMessage("Exam grade must be at most one digits long");
    }
}