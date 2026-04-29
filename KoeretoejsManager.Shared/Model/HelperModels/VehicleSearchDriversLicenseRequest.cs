using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Models.HelperModels
{
    public class VehicleSearchDriversLicenseRequest
    {
        public List<DrivingLicenseType> LicenseTypes { get; set; } = new();
    }
}
