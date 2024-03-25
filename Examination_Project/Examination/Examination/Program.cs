using Examination.data;
using Examination.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Examination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExamContext db = new ExamContext();
           
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<ITrackRepo,TrackRepo>();
            builder.Services.AddScoped<IstudentRepo, StudentRepo>();
            builder.Services.AddScoped<IInstructorRepo , InstructorRepo>();

            builder.Services.AddDbContext<ExamContext>(a =>
          a.UseSqlServer(builder.Configuration.GetConnectionString("Conn1")));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
