using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_.NET_MVC_lab.Filters
{
    public class LocationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments["location"].ToString().ToLower() !="usa" || context.ActionArguments["location"].ToString().ToLower() != "eg")
            {
                throw new Exception("NOT allowed if not from USA or EG");
            }
        }
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}
    }
}
