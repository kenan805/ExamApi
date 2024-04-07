namespace Exam.Application.ResponseModels.Results;

public class Result : IResponseResult
{
    public string[] Message { get; }
    public int StatusCode { get; }

    public Result(int statusCode)
    {
        StatusCode = statusCode;
    }

    public Result(int statusCode, params string[] message) : this(statusCode)
    {
        Message = message;
    }
}
