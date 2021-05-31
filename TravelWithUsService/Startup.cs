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
            services.AddDbContext<TravelWithUsDbContext>(options =>
                options.UseSqlServer($"Server=(localDB)\\MSSQLLocalDB;Database=TravelWithUsDB;Integrated Security=true;"));
            services.AddControllers()
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelWithUsService", Version = "v1" });
            });

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
