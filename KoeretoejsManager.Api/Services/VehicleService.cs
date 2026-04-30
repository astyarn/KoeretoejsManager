using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Mapper;
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
                .Select(v => VehicleMapper.ToVehicleDto(v))
                .ToList();
        }

        public List<VehicleSearchByDriverslicenseDTO> GetAllVehiclesByDriversLicense(List<DrivingLicenseType> drivingLicenseTypes)
        {
            return _db.Vehicles
                .Where(v => drivingLicenseTypes.Contains(v.RequiredLicense))
                .Select(v => VehicleMapper.ToVehicleSearchByDriverslicenseDto(v))
                .ToList();
        }
    }
}
