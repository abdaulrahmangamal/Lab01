using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_.NET_MVC_lab.Filters
{
    public class ExceptionHandleFilter : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult res = new ContentResult();
            //res.Content =$"An error Occured => {context.Exception.Message} => {context.ActionDescriptor.DisplayName}";
            ViewResult res = new ViewResult();
            res.ViewName = "Error";
            context.Result = res;
        }
    }
}
