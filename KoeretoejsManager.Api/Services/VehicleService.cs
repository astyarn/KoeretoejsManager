using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace KoeretoejsManager.Api.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly KoeretoejsManagerDbContext _db;

        public VehicleService(KoeretoejsManagerDbContext db)
        {
            _db = db;
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDTO> GetAllVehicles()
        {
            return _db.Vehicles
                .Select(v => new VehicleDTO
                {
                    VehicleId = v.VehicleId,
                    LicensePlate = v.LicensePlate,
                    RequiredLicense = v.RequiredLicense,
                    Status = v.Status,
                    NumberOfSeats = v.NumberOfSeats
                })
                .ToList();
        }

        public List<VehicleDTO> GetAllVehiclesByDriversLicense(List<DrivingLicenseType> drivingLicenseTypes)
        {
            return _db.Vehicles
                .Where(v => drivingLicenseTypes.Contains(v.RequiredLicense))
                .Select(v => new VehicleDTO
                {
                    VehicleId = v.VehicleId,
                    LicensePlate = v.LicensePlate,
                    RequiredLicense = v.RequiredLicense,
                    Status = v.Status,
                    NumberOfSeats = v.NumberOfSeats
                })
                .ToList();
        }
    }
}
