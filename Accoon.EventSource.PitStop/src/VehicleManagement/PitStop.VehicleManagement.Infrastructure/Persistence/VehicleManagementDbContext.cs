using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PitStop.VehicleManagement.Application.Interfaces;
using PitStop.VehicleManagement.Domain.Common;
using PitStop.VehicleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PitStop.VehicleManagement.Infrastructure.Persistence
{
    public class VehicleManagementDbContext : DbContext, IVehicleManagementDbContext
    {
        public VehicleManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        // db set of entites 
        public DbSet<Vehicle> Vehicles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // set creational and update details
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = String.Empty;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = String.Empty;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // read all IEntityTypeConfiguration data from this assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}

//Add-Migration changeid -Project PitStop.VehicleManagement.Infrastructure -StartupProject PitStop.VehicleManagement.Api
