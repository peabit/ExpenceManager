using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenceManager.Filters;

public class ResponseStatusCodeFilter : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext _) { }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        switch (context.HttpContext.Request.Method)
        {
            case "POST":
                context.HttpContext.Response.StatusCode = StatusCodes.Status201Created;
                break;

            case "PUT" or "DELETE":
                context.HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
                break;
        }
    }
}