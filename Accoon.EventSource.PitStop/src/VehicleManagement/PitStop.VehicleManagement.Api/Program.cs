using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PitStop.VehicleManagement.Infrastructure.Persistence;

namespace PitStop.VehicleManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                // auto migration to database and seeding 
                var services = scope.ServiceProvider;
                try
                {
                    // migrating
                    var context = services.GetRequiredService<VehicleManagementDbContext>();
                    context.Database.Migrate();

                    // seeding data
                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //await ApplicationDbContextSeed.SeedAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                }
            }
            
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
