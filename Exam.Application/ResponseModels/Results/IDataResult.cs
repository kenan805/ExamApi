namespace Exam.Application.ResponseModels.Results;

public interface IDataResult<T> : IResponseResult
{
    public T Data { get; }
}
