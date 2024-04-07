using Exam.Application.ResponseModels.Results;
using System.Net;
using System.Text.Json;

namespace Exam.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string message = ex.Message;

                Result? response = new Result((int)HttpStatusCode.InternalServerError, message);
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
