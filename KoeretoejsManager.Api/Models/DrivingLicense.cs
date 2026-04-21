using KoeretoejsManager.Shared.Enums;

namespace KoeretoejsManager.Api.Models
{
    public class DrivingLicense
    {
        public int DrivingLicenseId { get; set; }
        public DrivingLicenseType Type { get; set; }
        public List<UserDrivingLicense> UserDrivingLicense { get; set; }

    }
}
