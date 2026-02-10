namespace BackEnd.API.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BackEnd.API.Models.Responses;

public class ApiResponseWrapperFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var statusCode = objectResult.StatusCode ?? 200;
            var wrapped = new ApiResponse<object>(statusCode, objectResult.Value!);
            context.Result = new ObjectResult(wrapped)
            {
                StatusCode = statusCode
            };
        }
        else if (context.Result is EmptyResult)
        {
            context.Result = new ObjectResult(new ApiResponse<object>(200, null!));
        }
    }
}
