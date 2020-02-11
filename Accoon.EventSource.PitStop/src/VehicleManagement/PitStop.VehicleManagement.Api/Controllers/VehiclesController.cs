using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PitStop.VehicleManagement.Application.Vehicles.Commands.CreateVehicle;

namespace PitStop.VehicleManagement.Api.Controllers
{
   
    public class VehiclesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateVehicleCommand command) => 
            await Mediator.Send(command);
    }
}