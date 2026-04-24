using KoeretoejsManager.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace KoeretoejsManager.Api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<UserDrivingLicense> UserDrivingLicense { get; set; }

        public UserRoleType UserRole { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
 