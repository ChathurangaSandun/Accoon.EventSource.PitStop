using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PitStop.VehicleManagement.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandVelidator: AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandVelidator()
        {
            RuleFor(v => v.LicenseNumber).NotNull().NotEmpty();
            RuleFor(v => v.Brand).NotNull().NotEmpty();
            RuleFor(v => v.Type).NotNull().NotEmpty();
        }
    }
}
