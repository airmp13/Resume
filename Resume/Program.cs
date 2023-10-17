using Microsoft.EntityFrameworkCore;
using Resume.Application;
using Resume.Infrastructure;
using System;

namespace Resume
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IPersonalInformationService, PersonalInformationService>();

            builder.Services.AddScoped<IAllDTOService, AllDTOService>();

            builder.Services.AddDbContext<ResumeDbContext>(op =>
            op.UseSqlServer(builder.Configuration.GetConnectionString("ResumeDbContext")));
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}