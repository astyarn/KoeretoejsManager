using KoeretoejsManager.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Shared.DTOs
{
    public class CreateVehicleDTO
    {
        public string LicensePlate { get; set; }
        public DrivingLicenseType RequiredLicense { get; set; }
        public VehicleStatusType Status { get; set; }
        public int NumberOfSeats { get; set; }

    }
}
