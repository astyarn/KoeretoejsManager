using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Interfaces
{
    public interface IVehicleApiService
    {
        Task<List<VehicleDTO>> GetAllVehicles();
        Task<List<VehicleSearchByDriverslicenseDTO>> GetVehiclesByDrivingLicense(List<DrivingLicenseType> drivingLicenseTypes);
        Task<VehicleDTO?> CreateVehicle(CreateVehicleDTO dto);
        Task DeleteVehicle(int vehicleId);
    }
}
