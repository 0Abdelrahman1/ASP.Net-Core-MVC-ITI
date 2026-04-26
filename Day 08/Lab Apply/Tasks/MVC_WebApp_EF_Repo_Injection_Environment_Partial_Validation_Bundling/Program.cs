using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TraineesDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

            builder.Services.AddScoped<IBaseRepository<Course>, CourseRepository>();
            builder.Services.AddScoped<IBaseRepository<Trainee>, TraineeRepository>();
            builder.Services.AddScoped<IBaseRepository<Track>, TrackRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
