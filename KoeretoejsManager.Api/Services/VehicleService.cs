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

        public VehicleDTO CreateVehicle(CreateVehicleDTO dto)
        {
            var vehicle = new Vehicle
            {
                LicensePlate = dto.LicensePlate,
                RequiredLicense = dto.RequiredLicense,
                Status = dto.Status,
                NumberOfSeats = dto.NumberOfSeats
            };

            _db.Vehicles.Add(vehicle);
            _db.SaveChanges();
            return VehicleMapper.ToVehicleDto(vehicle);
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

        public VehicleDTO GetVehicleById(int vehicleId)
        {
            //TODO test what happens if null is tried to be mapped to a DTO, and if it throws an exception or just returns null.
            return _db.Vehicles
                .Where(v => v.VehicleId == vehicleId)
                .Select(v => VehicleMapper.ToVehicleDto(v))
                .FirstOrDefault();
        }

        public bool DeleteVehicle(int vehicleId)
        {
            var vehicle = _db.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);   //Check if the vehicle exists before trying to delete it

            if (vehicle == null)
                return false;

            _db.Vehicles.Remove(vehicle);
            _db.SaveChanges();

            return true;
        }
    }
}
