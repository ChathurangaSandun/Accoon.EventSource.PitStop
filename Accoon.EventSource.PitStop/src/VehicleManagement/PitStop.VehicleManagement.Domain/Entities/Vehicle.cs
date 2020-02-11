using PitStop.VehicleManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PitStop.VehicleManagement.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        public string Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }
    }
}
