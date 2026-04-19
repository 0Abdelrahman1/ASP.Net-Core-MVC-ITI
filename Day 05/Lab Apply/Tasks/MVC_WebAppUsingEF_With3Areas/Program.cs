namespace MVC_WebAppUsingEF_With3Areas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapAreaControllerRoute(
                name: "AdminArea",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            app.MapAreaControllerRoute(
                name: "FinanceArea",
                areaName: "Finance",
                pattern: "Finance/{controller=Home}/{action=Index}/{id?}");
            app.MapAreaControllerRoute(
                name: "HRArea",
                areaName: "HR",
                pattern: "HR/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Privacy}/{id?}");

            app.Run();
        }
    }
}
