using Exam.Domain.Entites.Common;
using Exam.Domain.Entites.Common.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entites;
public class Lesson : IEntity<int>, IAuditedEntity, ISoftDelete
{
    public string Code { get; set; }
    public string Name { get; set; }
    public short Class { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }

    public ICollection<Exam> Exams { get; set; }

    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public DateTime? DeletionTime { get; set; }
}