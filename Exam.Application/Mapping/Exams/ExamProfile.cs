using AutoMapper;
using Exam.Application.DTOs.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Mapping.Exams;
public class ExamProfile : Profile
{
    public ExamProfile()
    {
        CreateMap<Domain.Entites.Exam, GetExamDto>()
            .ForMember(dest => dest.LessonCode, opt => opt.MapFrom(src => src.Lesson.Code))
            .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.Student.No));
    }
}
