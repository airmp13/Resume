using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Implements;
using Resume.Application.Services.Interfaces;
using Resume.Domain.RepositoryInterfaces;
using Resume.Infrastructure;
using Resume.Infrastructure.Repositories;
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

            //Services injections
            builder.Services.AddScoped<ISinglePageService, SinglePageService>();
            builder.Services.AddScoped<IPersonalInformationService, PersonalInformationService>();
            builder.Services.AddScoped<IAboutMeService, AboutMeService>();
            builder.Services.AddScoped<IEducationService, EducationService>();
            builder.Services.AddScoped<IExperiencesService,ExperiencesService>();
            builder.Services.AddScoped<IMySkillsService, MySkillsService>();
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            builder.Services.AddScoped<IContactMeService, ContactMeService>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            //Repository Injections
            builder.Services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            builder.Services.AddScoped<IAboutMeRepository, AboutMeRepository>();
            builder.Services.AddScoped<IEducationRepository, EducationRepository>();
            builder.Services.AddScoped<IExperiencesRepository, ExperiencesRepository>();
            builder.Services.AddScoped<IMySkillsRepository, MySkillsRepository>();
            builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
            builder.Services.AddScoped<IContactMeRepository, ContactMeRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            // Sql Injection

            builder.Services.AddDbContext<ResumeDbContext>(op =>
            op.UseSqlServer(builder.Configuration.GetConnectionString("ResumeDbContext")));


            //Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                // Add Cookie settings
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                });


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
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}