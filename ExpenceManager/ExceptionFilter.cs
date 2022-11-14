using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenceManager;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        _ = 1;
    }
}
