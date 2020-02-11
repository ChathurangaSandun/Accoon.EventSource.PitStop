using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PitStop.VehicleManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PitStop.VehicleManagement.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddIntrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VehicleManagementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(VehicleManagementDbContext).Assembly.FullName)));

            return services;
        }
    }
}
