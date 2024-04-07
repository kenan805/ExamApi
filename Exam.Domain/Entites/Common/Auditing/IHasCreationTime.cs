namespace Exam.Domain.Entites.Common.Auditing;

public interface IHasCreationTime
{
    DateTime CreationTime { get; set; }
}