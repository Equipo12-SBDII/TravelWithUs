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
using TravelWithUsService.DBContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


using System.IO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

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
            // string databasePath = System.IO.Path.Combine(
            //     "..", "TravelWithUsDB.db");
            // services.AddDbContext<TravelWithUsDbContext>(options =>
            //     options.UseSqlite($"Data Source={databasePath}")
            // );

            services.AddDbContext<DBContext.TravelWithUsDbContext>(options =>
                options.UseSqlServer($"Server=(localDB)\\MSSQLLocalDB;Database=TravelWithUsDB;Integrated Security=true;"));

            this.Migrate(services.BuildServiceProvider());

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });


            services.AddControllers().AddNewtonsoftJson(
                options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelWithUsService", Version = "v1" });
            });


            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("ManageRolesAndClaimsPolicy",
            //         policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

            //     options.AddPolicy("DeleteRolePolicy",
            //         policy => policy.RequireClaim("Delete Role", "true"));

            //     options.AddPolicy("EditRolePolicy",
            //         policy => policy.RequireClaim("Edit Role", "true"));

            //     options.AddPolicy("CreateRolePolicy",
            //         policy => policy.RequireClaim("Create Role", "true"));

            //     options.AddPolicy("AdminRolePolicy",
            //         policy => policy.RequireRole("Admin"));
            // });

            services.AddScoped<IAgencia, AgenciaRepository>();
            services.AddScoped<IExcursion, ExcursionRepository>();
            services.AddScoped<IFacilidad, FacilidadRepository>();
            services.AddScoped<IHotel, HotelRepository>();
            services.AddScoped<IOferta, OfertaRepository>();
            services.AddScoped<IPaquete, PaqueteRepository>();
            services.AddScoped<IReservaExcursion, ReservaExcursionRepository>();
            services.AddScoped<IReservaIndividual, ReservaIndividualRepository>();
            services.AddScoped<IReservaPaquete, ReservaPaqueteRepository>();
            services.AddScoped<ITurista, TuristaRepository>();
            services.AddScoped<IRequestsRepository, RequestsRepository>();


            // services.AddScoped<IAuthorizationHandler, CanEditOtherAdminRolesAndClaimsHandler>();
            // services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelWithUsService v1");

                    c.SupportedSubmitMethods(new[] {SubmitMethod.Get, SubmitMethod.Post,
                    SubmitMethod.Put, SubmitMethod.Delete });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void Migrate(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<DBContext.TravelWithUsDbContext>>();
            logger.LogInformation("Migrating database schema");
            var context = serviceProvider.GetRequiredService<DBContext.TravelWithUsDbContext>();
            // context.Database.EnsureDeleted();
            context.Database.Migrate();
        }
    }
}
