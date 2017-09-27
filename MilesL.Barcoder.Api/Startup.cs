using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using MilesL.Barcoder.Api.Repositories.Interfaces;
using MilesL.Barcoder.Api.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using MilesL.Barcoder.Api.Services.Interfaces;
using MilesL.Barcoder.Api.Services;
using AutoMapper;

namespace MilesL.Barcoder.Api
{
    /// <summary>
    /// Startup configuration for .Net Core
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initialises a instance of the <see cref="Startup"/> class
        /// </summary>
        /// <param name="configuration">A instance of the IConfiguration interface</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// A instance of the IConfiguration interface
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add mvc support
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

            // Add automapper
            services.AddAutoMapper();

            // Register dependencies
            services.AddScoped<IBarcodeRepository, BarcodeRepository>();
            services.AddScoped<IBarcodeService, BarcodeService>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">A instance of the IApplicationBuilder interface</param>
        /// <param name="env">A instance of the IHostingEnvironment interface</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enables development mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Adds Swagger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Barcoder Api");
            });

            // Adds MVC
            app.UseMvc();
        }
    }
}
