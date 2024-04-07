namespace Exam.Domain.Entites.Common.Auditing;

public interface IHasModificationTime
{
    DateTime? LastModificationTime { get; set; }
}