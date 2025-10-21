using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ASP_.NET_MVC_lab.Filters
{
    public class ResultFilter :ResultFilterAttribute
    {
        Stopwatch dw = new Stopwatch();
        public override void  OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Result filter  Excuted");
            dw.Start();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Before Result Filter is excuting");
            dw.Stop();
            Console.WriteLine($"From result filter {dw.ElapsedMilliseconds}MS");
        }
    }
}
