using ASP_.NET_MVC_lab.Context;
using ASP_.NET_MVC_lab.Filters;
using ASP_.NET_MVC_lab.Middleware;
using ASP_.NET_MVC_lab.Repos;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ASP_.NET_MVC_lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                    .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                //builder.Services.AddSerilog();

                builder.Services.AddDistributedMemoryCache();
                builder.Services.AddSession(option =>
                {
                    option.IdleTimeout = TimeSpan.FromMinutes(10);
                    option.Cookie.HttpOnly = true;
                    option.Cookie.IsEssential = true;
                });
                builder.Services.AddScoped<ISchoolGenericRepository, SchoolGenericRepository>();
                builder.Services.AddDbContext<SchoolContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });
                // Add services to the container.
                builder.Services.AddControllersWithViews(op =>
                {
                    op.Filters.Add<ExceptionHandleFilter>();
                    op.Filters.Add<ResultFilter>();
                    op.Filters.Add<ResourceFilter>();
                });

                var app = builder.Build();
                //app.MapGet("/", () => "Hello World!");
                //app.UseMiddleware<IloggerMiddleware>();
                //app.UseMiddleware<GlobalExceptionHandleMiddleware>();
                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseSession();
                app.UseRouting();

                app.UseAuthorization();

                app.MapStaticAssets();
                app.MapControllerRoute(
                    name: "students",
                    pattern:"/std",
                    defaults: new {controller="student",action="getall"});

                app.MapControllerRoute(
                 name: "departments",
                 pattern: "/dpt",
                 defaults: new { controller = "department", action = "getall" });

                app.MapControllerRoute(
                 name: "instructors",
                 pattern: "/inst",
                 defaults: new { controller = "instructor", action = "getall" });

                app.MapControllerRoute(
                 name: "courses",
                 pattern: "/crs",
                 defaults: new { controller = "course", action = "getall" });

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=getall}/{id?}")
                    .WithStaticAssets();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}

//app.Use(async (context, next) =>
//{
//     Console.WriteLine("hello from middleware1");
//    await next();
//     Console.WriteLine(" hello from response1");
//});
//app.Use(async (context, next) =>
//{
//     Console.WriteLine("hello from middleware2");
//    await next();
//     Console.WriteLine(" hello from response 2");
//});

//app.UseMiddleware<LoggingMiddleware>();
//app.UseLoggingMiddleware();