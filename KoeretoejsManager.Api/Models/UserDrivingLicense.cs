namespace KoeretoejsManager.Api.Models
{
    public class UserDrivingLicense
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int DrivingLicenseId { get; set; }
        public DrivingLicense DrivingLicense { get; set; }

        public DateTime ExpiryDate { get; set; }   

    }
}
