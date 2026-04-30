using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IVehicleService
    {
        List<VehicleDTO> GetAllVehicles();
        VehicleDTO GetVehicleById(int vehicleId);
        List<VehicleSearchByDriverslicenseDTO> GetAllVehiclesByDriversLicense(List<DrivingLicenseType> drivingLicenseTypes);
        VehicleDTO CreateVehicle(CreateVehicleDTO vehicle);
        bool DeleteVehicle(int id);
    }
}
