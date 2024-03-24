using Examination.data;
using Examination.Repos;
using Microsoft.EntityFrameworkCore;

namespace Examination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExamContext db = new ExamContext();
            //var student = db.Students.Single(d=>d.Id==1);
            //Console.WriteLine(student.Fname);
            //var track = db.Tracks.Single(d=>d.Id==1);
            //Console.WriteLine(track);
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<ITrackRepo,TrackRepo>();
            builder.Services.AddScoped<IstudentRepo, StudentRepo>();
            builder.Services.AddScoped<IInstructorRepo , InstructorRepo>();

            builder.Services.AddDbContext<ExamContext>(a =>
          a.UseSqlServer(builder.Configuration.GetConnectionString("Conn1")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Instructor}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
