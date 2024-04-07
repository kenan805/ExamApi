using Exam.Application.Repositories;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories;
public class LessonRepository : EfRepository<Domain.Entites.Lesson>, ILessonRepository
{
    public LessonRepository(ExamDbContext context) : base(context)
    {
    }
}