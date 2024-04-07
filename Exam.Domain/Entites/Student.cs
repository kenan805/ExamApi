using Exam.Domain.Entites.Common;
using Exam.Domain.Entites.Common.Auditing;

namespace Exam.Domain.Entites;

public class Student : IEntity<int>, IAuditedEntity, ISoftDelete
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public short Class { get; set; }

    public ICollection<Exam> Exams { get; set; }

    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public DateTime? DeletionTime { get; set; }
}
