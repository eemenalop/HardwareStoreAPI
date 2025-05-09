using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class LoginFilter : IActionFilter
{
    private readonly ILogger<LoginFilter> _logger;

    public LoginFilter(ILogger<LoginFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"Nueva solicitud: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"Acción ejecutada: {context.ActionDescriptor.DisplayName}");
    }
}