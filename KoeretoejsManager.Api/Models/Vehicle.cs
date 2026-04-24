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

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        //property for location
        //property for cargocapacity
    }
}
