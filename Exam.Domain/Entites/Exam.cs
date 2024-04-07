using Exam.Domain.Entites.Common;
using Exam.Domain.Entites.Common.Auditing;

namespace Exam.Domain.Entites;

public class Exam : IEntity<int>, IAuditedEntity, ISoftDelete
{
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
    public short Grade { get; set; }

    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public DateTime? DeletionTime { get; set; }
}