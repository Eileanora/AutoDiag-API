using Microsoft.AspNetCore.Diagnostics;


namespace IntelligentDiagnostician.API.Helpers.ExceptionHandler
{
    internal sealed class UnauthorizedAccessExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<UnauthorizedAccessExceptionHandler> _logger;

        public UnauthorizedAccessExceptionHandler(ILogger<UnauthorizedAccessExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not UnauthorizedAccessException unauthorizedAccessException)
                return false;

            _logger.LogError(
                unauthorizedAccessException,
                "Unauthorized access exception occurred: {Message}",
                unauthorizedAccessException.Message);

            httpContext.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Unauthorized access", cancellationToken);
            return true;
        }
    }
}
