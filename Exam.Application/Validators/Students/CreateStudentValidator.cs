using Exam.Application.Features.Commands.Lesson;
using Exam.Application.Features.Commands.Student;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Students;
public class CreateStudentValidator : AbstractValidator<CreateStudentCommandRequest>
{
    public CreateStudentValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
                .WithMessage("Enter student name")
            .MaximumLength(30)
                .WithMessage("Student name maximum length must be 30");

        RuleFor(s => s.Surname)
            .NotEmpty()
                .WithMessage("Enter student surname")
            .MaximumLength(30)
                .WithMessage("Student surname maximum length must be 30");

        RuleFor(s => s.No)
            .NotEmpty()
                .WithMessage("Enter student no")
            .InclusiveBetween(1, 99999)
                .WithMessage("Student no must be at most five digits long");

        RuleFor(s => s.Class)
            .NotEmpty()
                .WithMessage("Enter student class")
            .InclusiveBetween((short)1, (short)99)
                .WithMessage("Student class must be at most two digits long");
    }
}
