using MediatR;
using PitStop.VehicleManagement.Application.Interfaces;
using PitStop.VehicleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PitStop.VehicleManagement.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand: IRequest<long>
    {
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }

        public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, long>
        {
            private readonly IVehicleManagementDbContext _context;

            public CreateVehicleCommandHandler(IVehicleManagementDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
            {
                var vehicle = new Vehicle
                {
                    LicenseNumber = request.LicenseNumber,
                    Brand = request.Brand,
                    Type = request.Type
                };

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync(cancellationToken);
                return vehicle.Id;
            }
        }
    }
}
