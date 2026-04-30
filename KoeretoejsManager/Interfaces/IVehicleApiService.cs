using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Interfaces
{
    public interface IVehicleApiService
    {
        Task<List<VehicleSearchByDriverslicenseDTO>> GetAllVehicles();
        Task<List<VehicleSearchByDriverslicenseDTO>> GetVehiclesByDrivingLicense(List<DrivingLicenseType> drivingLicenseTypes);
    }
}
