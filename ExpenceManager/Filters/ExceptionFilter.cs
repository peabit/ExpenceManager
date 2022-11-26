using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Exceptions;

namespace ExpenceManager.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ServiceException)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        if (context.Exception is NotFoundException)
        {
            context.Result = new NotFoundObjectResult(context.Exception.Message);
            return;
        }

        context.Result = new ConflictObjectResult(context.Exception.Message);
    }
}