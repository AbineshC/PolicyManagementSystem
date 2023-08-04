using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Assignment.Infrastructure;
using Assignment.Core;
using Microsoft.AspNetCore.Mvc;
using Assignment.Core.Security;
using Assignment.Contracts.Data.Repositories;
using Assignment.Infrastructure.Data.Repositories;
using Assignment.Contracts.Data.Entities;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using FluentValidation.AspNetCore;
using Serilog;
using Microsoft.Extensions.Logging.AzureAppServices;

namespace Assignment
{
    public class Startup
    {
        public const string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddPersistence(Configuration);
            services.AddCore();
            services.AddMarketplaceAuthentication(Configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddFluentValidationRulesToSwagger();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLog>>();
            services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger), logger);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(); 
                builder.AddSerilog();
                builder.AddEventLog();
            });

            services.AddControllers(config =>

            {

                    config.EnableEndpointRouting = false;

            }).AddFluentValidation(fv =>

            {

              fv.ImplicitlyValidateRootCollectionElements = true;

             });


            //var builder = WebApplication.CreateBuilder();
            //builder.Logging.AddAzureWebAppDiagnostics();
            //builder.Services.Configure<AzureFileLoggerOptions>(options =>
            //{
            //    options.FileName = "log";
            //    options.FileSizeLimit = 50 * 1024;
            //    options.RetainedFileCountLimit = 5;
            //});
            //builder.Services.Configure<AzureBlobLoggerOptions>(options =>
            //{
            //    options.BlobName = "log.txt";
            //});



            services.AddScoped<IPolicyRepository<Policy>, PolicyRepository>();
            services.AddScoped<IClaimRepository<Claim>, ClaimRepository>();
            services.AddScoped<IApprovalHistoryRepository<ApprovalHistory>, ApprovalHistoryRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aspire Assignment App API", Description = "Aspire Assignment App  is a  solution, built to demonstrate the trainees to create the application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.WithOrigins("https://localhost:44491/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            //     .AllowAnyHeader()
            //.AllowAnyMethod()
            //.AllowAnyOrigin()

            app.UseHttpsRedirection();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aspire Assignment App API v1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
