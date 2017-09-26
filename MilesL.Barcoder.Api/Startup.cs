using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;
using MilesL.Barcoder.Api.Repositories.Interfaces;
using MilesL.Barcoder.Api.Repositories;
using System.Data;
using System.Data.SqlClient;
using MilesL.Barcoder.Api.Services.Interfaces;
using MilesL.Barcoder.Api.Services;
using AutoMapper;

namespace MilesL.Barcoder.Api
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
            services.AddMvc();

            // Configure versioning support
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Add swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Barcoder Api",
                    Description = "This barcoder api is a simple .NET Core WebApi that provides functionality for managing barcodes",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Luke Miles", Email = "lukemiles@outlook.com", Url = "https://lmiles.co.uk" }
                });
            });

            services.AddAutoMapper();

            services.AddScoped<IBarcodeRepository, BarcodeRepository>();
            services.AddScoped<IBarcodeService, BarcodeService>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barcoder Api");
            });

            app.UseMvc();
        }
    }
}
