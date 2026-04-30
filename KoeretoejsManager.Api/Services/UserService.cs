using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Mapper;
using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Api.Services
{
    public class UserService : IUserService
    {
        private readonly KoeretoejsManagerDbContext _db;

        public UserService(KoeretoejsManagerDbContext db)
        {
            _db = db;
        }

        public List<UserIdDTO> GetAllUserIds()
        {
            return _db.Users.Select(u => UserMapper.ToUserIdDto(u)).ToList();
        }

        public UserProfileDTO GetUserById(int id)
        {
            return _db.Users
                .Where(u => u.UserId == id)
                .Select(u => new UserProfileDTO
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    UserRole = u.UserRole,

                    Licenses = u.UserDrivingLicense.Select(udl => new UserDrivingLicenseDTO
                    {
                        DrivingLicenseId = udl.DrivingLicenseId,
                        Type = udl.DrivingLicense != null
                            ? udl.DrivingLicense.Type
                            : default,
                        ExpiryDate = udl.ExpiryDate
                    }).ToList(),

                    Bookings = u.Bookings.Select(b => new BookingDTO
                    {
                        BookingId = b.BookingId,
                        Start = b.Start,
                        End = b.End,

                        Vehicle = new VehicleDTO
                        {
                            VehicleId = b.Vehicle.VehicleId,
                            LicensePlate = b.Vehicle.LicensePlate,
                            RequiredLicense = b.Vehicle.RequiredLicense,
                            Status = b.Vehicle.Status,
                            NumberOfSeats = b.Vehicle.NumberOfSeats
                        }
                    }).ToList()
                })
                .FirstOrDefault();
        }
    }
}

