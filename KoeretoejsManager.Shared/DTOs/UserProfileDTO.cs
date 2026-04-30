using KoeretoejsManager.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Shared.DTOs
{
    public class UserProfileDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserRoleType UserRole { get; set; }

        public List<UserDrivingLicenseDTO> Licenses { get; set; }

        public List<BookingDTO> Bookings { get; set; }

    }
}
