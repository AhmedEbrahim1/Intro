using Intro.Filters;
using Intro.Models;
using Intro.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();/*.AddSessionStateTempDataProvider();*/

            #region Global Exception Handling
            //builder.Services.AddControllersWithViews(options => {

            //    options.Filters.Add(new HandleErrorAttribute());

            //}).AddSessionStateTempDataProvider(); 
            #endregion

            //register ==> 1 
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<RwadMisrConext>();


            builder.Services.AddDbContext<RwadMisrConext>(options =>
            {
                //options.UseSqlServer("Data Source=.;Initial Catalog=ITI_Net;Integrated Security=True");
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });



            #region Generic Repo , SQLProvider
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //builder.Services.AddDbContext<RwadMisrConext>(options =>
            //{
            //    //options.UseSqlServer("Data Source=.;Initial Catalog=MVCSecondDemo;Integrated Security=True");
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            //});
            #endregion
            var app = builder.Build();

            #region Built-In MW
            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//No need Routing (img,html,css,js) ==> Wwwroot ==> (short circle ) 

            app.UseRouting();// in the Url have Routing (not extension),controllerName=DepartmentController,ActionName = Index

            app.UseAuthentication();//Who Are You ?! ==< User have cookies (
            app.UseAuthorization(); // Role ?!
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//create object of controller, call the action
            #endregion


            #region Routing 

            //app.MapControllerRoute(
            //   name: "MyRouteTwo",
            //     pattern: "emp/{id:int}",
            //     defaults:new { controller = "Employee", action ="Details" } 
            //     );


            //app.MapControllerRoute(
            //    name: "MyRoute",
            ////pattern: "{controller=Home}/{action=Index}/{name}/{age}");
            ////pattern: "{controller=Home}/{action=Index}/{name}/{age:int}");//with restriction 
            //pattern: "{controller=Home}/{action=Index}/{name}/{age:int:range(10,30)}");//with restriction 



            //app.MapControllerRoute( //don't need to add End Point ( old Version ) it's Replacement 
            //    name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}"); //==> create object of controller , call the action
            //1 ==> xyz
            //pattern: "{controller=Home}/{action=Index}/{xyz?}");


            #endregion


            #region Inline MW

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response = "Ali";  //error
            //    await context.Response.WriteAsync("1- Middle 1\n");
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    //Example of Terminate 
            //    //await context.Response = "Ali";  //error
            //    await context.Response.WriteAsync("1- Middle 1\n");
            //    if (context.Request.Method == "POST")
            //        await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("2- Middle 2"); //momoken mktbhash 
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("3- Middleware 3 Terminate\n");
            //});

            #endregion


            app.Run();
        }
    }
}