using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_.NET_MVC_lab.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("On resource excuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("On resource excuting before model binding");
        }
    }
}
