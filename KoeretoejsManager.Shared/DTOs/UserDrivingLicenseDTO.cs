using KoeretoejsManager.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Shared.DTOs
{
    public class UserDrivingLicenseDTO
    {
        public int DrivingLicenseId { get; set; }
        public DrivingLicenseType Type { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
