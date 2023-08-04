using Assignment.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();
            //builder.Logging.AddFile("Logs/myapp-{Date}.txt");
    //        Host.CreateDefaultBuilder(args)
    //.ConfigureWebHostDefaults(webHost =>
    //{
    //    webHost.UseStartup<Startup>();
    //})
    //.ConfigureLogging((hostingContext, loggingBuilder) =>
    //{
    //    loggingBuilder.AddFile("Logs/myapp-{Date}.txt");
       
    //})
    //.Build();

            using var scope = builder.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
