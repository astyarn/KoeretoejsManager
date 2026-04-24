using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public DrivingLicenseType RequiredLicense { get; set; }
        public VehicleStatusType Status { get; set; }
        public int NumberOfSeats { get; set; }

        //property for location
        //property for cargocapacity
    }
}
