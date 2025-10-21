namespace ASP_.NET_MVC_lab.Middleware
{
    public class SerilogMiddleware
    {
        private RequestDelegate next;

        public SerilogMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task Invoke(HttpContext context)
        {

        }
    }
}
