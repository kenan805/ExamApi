using Exam.Application.Repositories;
using Exam.Persistence.Contexts;
using Exam.Persistence.Repositories.Base;

namespace Exam.Persistence.Repositories;

public class StudentRepository : EfRepository<Domain.Entites.Student>, IStudentRepository
{
    public StudentRepository(ExamDbContext context) : base(context)
    {
    }
}