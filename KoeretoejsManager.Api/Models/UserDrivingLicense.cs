namespace KoeretoejsManager.Api.Models
{
    public class UserDrivingLicense //Role table for User and drivingLicense many to many relation
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int DrivingLicenseId { get; set; }
        public DrivingLicense DrivingLicense { get; set; }

        public DateTime ExpiryDate { get; set; }   

    }
}
