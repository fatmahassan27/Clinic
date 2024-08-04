using DMS.BLL.AutoMapper;
using DMS.BLL.Interfaces;
using DMS.BLL.Services;
using DMS.DAL.Database;
using DMS.DAL.Interfaces;
using DMS.DAL.Repositories;
using DMS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DMS.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("myConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IPatientRepo,PatientRepo>();
            builder.Services.AddScoped<IShiftRepo, ShiftRepo>();
            // Register services

            builder.Services.AddScoped<IAppointmentService,AppointmentService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IPatientService,PatientService>();
            builder.Services.AddScoped<IShiftService, ShiftService>();

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
