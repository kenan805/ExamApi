using Exam.Application.Repositories;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories.Base;

namespace Exam.Persistence.Repositories;

public class ExamRepository : EfRepository<Domain.Entites.Exam>, IExamRepository
{
    public ExamRepository(ExamDbContext context) : base(context)
    {
    }
}
