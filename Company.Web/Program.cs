using Company.Data.Context;
using Company.Repositry.Interfaces;
using Company.Repositry.Repositries;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Employee;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Company.Service.Services;
using Company.Service.Mapping;
using Company.Service.Interfaces.Employee.DTO;
using Company.Service.Interfaces.Department.DTO;

namespace Company.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDbContext>(Options=>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));

            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //builder.Services.AddScoped<IDepartmentRepositry, DepartmentRepositry>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<EmployeeDto>();
            builder.Services.AddScoped<DepartmentDto>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmetProfile()));
            



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
