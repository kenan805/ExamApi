namespace Exam.Domain.Entites.Common;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}