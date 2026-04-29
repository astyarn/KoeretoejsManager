using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Api.Mapper
{
    public static class VehicleMapper
    {
        public static VehicleDTO ToDto(Vehicle entity)
        {
            return new VehicleDTO
            {
                VehicleId = entity.VehicleId,
                LicensePlate = entity.LicensePlate,
                RequiredLicense = entity.RequiredLicense,
                Status = entity.Status,
                NumberOfSeats = entity.NumberOfSeats
            };
        }
    }
}
