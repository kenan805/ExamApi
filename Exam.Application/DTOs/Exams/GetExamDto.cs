using Exam.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.Exams;
public class GetExamDto
{
    public string LessonCode { get; set; }
    public int StudentNumber { get; set; }
    public DateTime Date { get; set; }
    public short Grade { get; set; }
}
