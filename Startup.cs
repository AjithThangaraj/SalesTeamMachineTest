using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SalesTeamMachineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTeamMachineTest
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
            services.AddControllers();

            //Add dependency injection for DemoEmployeeDBContext
            services.AddDbContext<salesTeamContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("developConnection")));

            //add services for Repository Layer
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<ILoginRepository, LoginRepository>();
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //the rest of services
            //adding services
            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    //enables text json - display exact match
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                    //enables to avoid infinte loop - Recursive
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
