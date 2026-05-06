using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Api.Services;
using KoeretoejsManager.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Test.Api
{
    public class VehicleServiceTest
    {
        private KoeretoejsManagerDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<KoeretoejsManagerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // isolated DB per test
                .Options;

            return new KoeretoejsManagerDbContext(options);
        }

        private VehicleService CreateService(KoeretoejsManagerDbContext db)
        {
            return new VehicleService(db);
        }

        [Fact]
        public void GetAllVehicles_ReturnsAllVehicles()
        {
            // Arrange
            var db = CreateDbContext();

            db.Vehicles.AddRange(
                new Vehicle { VehicleId = 1, LicensePlate = "AA111", RequiredLicense = DrivingLicenseType.B },
                new Vehicle { VehicleId = 2, LicensePlate = "BB222", RequiredLicense = DrivingLicenseType.C }
            );

            db.SaveChanges();

            var service = CreateService(db);

            // Act
            var result = service.GetAllVehicles();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetVehicleById_ReturnsCorrectVehicle()
        {
            // Arrange
            var db = CreateDbContext();

            db.Vehicles.AddRange(
                new Vehicle { VehicleId = 1, LicensePlate = "AA111", RequiredLicense = DrivingLicenseType.B },
                new Vehicle { VehicleId = 2, LicensePlate = "BB222", RequiredLicense = DrivingLicenseType.C }
            );

            db.SaveChanges();

            var service = CreateService(db);

            // Act
            var result = service.GetVehicleById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("AA111", result.LicensePlate);
        }

        [Fact]
        public void GetVehicleById_ReturnsCorrectVehicle2()
        {
            // Arrange
            var db = CreateDbContext();

            db.Vehicles.AddRange(
                new Vehicle { VehicleId = 1, LicensePlate = "AA111", RequiredLicense = DrivingLicenseType.B },
                new Vehicle { VehicleId = 2, LicensePlate = "BB222", RequiredLicense = DrivingLicenseType.C }
            );

            db.SaveChanges();

            var service = CreateService(db);

            // Act
            var result = service.GetVehicleById(1);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("BB222", result.LicensePlate);
        }
    }
}
