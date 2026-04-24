using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IVehicleService
    {
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllVehiclesByDriversLicense(List<DrivingLicenseType> drivingLicenseTypes);
        bool CreateVehicle(Vehicle vehicle);
    }
}
