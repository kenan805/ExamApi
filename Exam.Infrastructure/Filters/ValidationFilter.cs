using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.ResponseModels.Results;
using Microsoft.AspNetCore.Http;

namespace Exam.Infrastructure.Filters;
public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            string[] errors = context.ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToArray();

            Result result = new(StatusCodes.Status400BadRequest, errors);
            context.Result = new OkObjectResult(result);
            return;
        }

        await next();
    }
}