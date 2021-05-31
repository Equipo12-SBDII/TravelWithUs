using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace TravelWithUsService
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
            string databasePath = System.IO.Path.Combine(
                "..", "TravelWithUsDB.db");
            services.AddDbContext<TravelWithUsDbContext>(options =>
                options.UseSqlite($"Data Source={databasePath}")
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelWithUsService", Version = "v1" });
            });

             services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageRolesAndClaimsPolicy",
                    policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role", "true"));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role", "true"));

                options.AddPolicy("CreateRolePolicy",
                    policy => policy.RequireClaim("Create Role", "true"));

                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin"));
            });


            services.AddScoped<IAgencia, AgenciaRepository>()
            .AddScoped<IExcursion, ExcursionRepository>()
            .AddScoped<IFacilidad, FacilidadRepository>()
            .AddScoped<IHotel, HotelRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelWithUsService v1"));
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
