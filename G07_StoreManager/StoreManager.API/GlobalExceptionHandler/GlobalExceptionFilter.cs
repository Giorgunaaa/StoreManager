using Microsoft.AspNetCore.Mvc.Filters;

namespace StoreManager.API.GlobalExceptionHandler;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult("An internal server error occurred.")
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}