namespace Exam.Domain.Entites.Common.Auditing;

public interface IHasDeletionTime
{
    DateTime? DeletionTime { get; set; }
}
