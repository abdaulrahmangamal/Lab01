namespace ASP_.NET_MVC_lab.Middleware
{
    public static class UseLoggingMiddlewareStatic
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
