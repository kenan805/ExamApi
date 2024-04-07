namespace Exam.Application.ResponseModels.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, int statusCode) : base(statusCode)
    {
        Data = data;
    }


    public DataResult(T data, int statusCode, params string[] message) : base(statusCode, message)
    {
        Data = data;
    }

    public DataResult(int statusCode, params string[] message) : base(statusCode, message)
    {

    }
    public T Data { get; }

}
