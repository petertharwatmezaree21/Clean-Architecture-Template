using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture_Repositry;
using CleanArchitecture_Repositry.ApplicationContext;
using ClearArchitecture_Service.Bussiness;
using ClearArchitecture_Service.Interfaces;
using ClearArchitecture_Service.UnitofWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddScoped(typeof(IRepositry<>), typeof(Repositry<>));
            services.AddScoped(typeof(IEmployeeRepositry), typeof(EmployeeRepositry));
            services.AddScoped(typeof(IDepartmentRepositry), typeof(DepartmentRepositry));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
