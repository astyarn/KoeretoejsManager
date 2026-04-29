using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IVehicleService
    {
        List<VehicleDTO> GetAllVehicles();
        List<VehicleDTO> GetAllVehiclesByDriversLicense(List<DrivingLicenseType> drivingLicenseTypes);
        bool CreateVehicle(Vehicle vehicle);
    }
}
