namespace EmployeeManagementSystem.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Try to get "id" from route data (like /employee/1027)
            string employeeId = context.Request.RouteValues.TryGetValue("id", out var routeId)
                ? routeId?.ToString()
                : null;

            // If not found in route, try to get from query string (like ?id=1027)
            if (string.IsNullOrEmpty(employeeId))
            {
                employeeId = context.Request.Query["id"].ToString();
            }

            _logger.LogInformation("Request received: Method={Method}, Path={Path}, EmployeeId={EmployeeId}",
                method, path, employeeId ?? "N/A");

            await _next(context);
        }
    }

}
