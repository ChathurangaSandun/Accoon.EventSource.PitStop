using Microsoft.EntityFrameworkCore;
using PitStop.VehicleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PitStop.VehicleManagement.Application.Interfaces
{
    public interface IVehicleManagementDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
