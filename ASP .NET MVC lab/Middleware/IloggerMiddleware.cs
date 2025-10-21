namespace ASP_.NET_MVC_lab.Middleware
{
    public class IloggerMiddleware
    {
        private RequestDelegate next;
        private ILogger<IloggerMiddleware> logger;

        public IloggerMiddleware(RequestDelegate _next, ILogger<IloggerMiddleware> _logger)
        {
            next = _next;
            logger = _logger;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.LogInformation($"ILOGGER =====>>{context.Request.Method}, {context.Response.StatusCode}");
            await next(context);
        }
    }
}
