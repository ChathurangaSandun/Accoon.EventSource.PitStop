using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PitStop.VehicleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PitStop.VehicleManagement.Infrastructure.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(t => t.LicenseNumber).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Brand).IsRequired();
            builder.Property(t => t.Type).IsRequired();
        }
    }
}

//Add-Migration InitMigration -Project PitStop.VehicleManagement.Infrastructure -StartupProject PitStop.VehicleManagement.Api -Context VehicleManagementDbContext
