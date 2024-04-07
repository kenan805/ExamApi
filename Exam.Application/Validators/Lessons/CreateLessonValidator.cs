using Exam.Application.Features.Commands.Lesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Lessons;
public class CreateLessonValidator : AbstractValidator<CreateLessonCommandRequest>
{
    public CreateLessonValidator()
    {
        RuleFor(l => l.Code)
            .NotEmpty()
                .WithMessage("Enter lesson code")
            .MaximumLength(3)
                .WithMessage("Lesson code maximum length must be 3");

        RuleFor(l => l.Name)
            .NotEmpty()
                .WithMessage("Enter lesson name")
            .MaximumLength(30)
                .WithMessage("Lesson name maximum length must be 30");

        RuleFor(l => l.Class)
            .NotEmpty()
                .WithMessage("Enter lesson class")
            .InclusiveBetween((short)1,(short)99)
                .WithMessage("Lesson class must be at most two digits long");

        RuleFor(l => l.TeacherName)
            .NotEmpty()
                .WithMessage("Enter teacher name")
            .MaximumLength(20)
                .WithMessage("Teacher name maximum length must be 20");

        RuleFor(l => l.TeacherSurname)
            .NotEmpty()
                .WithMessage("Enter teacher surname")
            .MaximumLength(20)
                .WithMessage("Teacher surname maximum length must be 20");
    }
}
