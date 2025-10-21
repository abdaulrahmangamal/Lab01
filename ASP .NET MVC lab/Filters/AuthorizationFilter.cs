using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP_.NET_MVC_lab.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("user")== "admin")
            {
                context.Result = new ViewResult()
                {
                    ViewName = "unauthorized",
                    StatusCode = 403

                };
                Console.WriteLine($"FROM AUTHORIZATION FILTER =====> { context.HttpContext.Session.GetString("user")}");
            }
            

        }
    }
}
