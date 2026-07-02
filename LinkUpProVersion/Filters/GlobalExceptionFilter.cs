using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LinkUpProVersion.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception server-side but do not expose details to client
            _logger.LogError(context.Exception, "Unhandled exception caught by GlobalExceptionFilter");

            var result = new RedirectToActionResult("Error", "Home", null);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
