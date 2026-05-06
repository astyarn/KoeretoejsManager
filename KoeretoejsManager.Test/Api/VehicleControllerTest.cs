using KoeretoejsManager.Api.Controllers;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoeretoejsManager.Test.Api
{
    public class VehicleControllerTest
    {
        private readonly Mock<IVehicleService> _vehicleServiceMock;
        private readonly VehicleController _controller;

        public VehicleControllerTest()
        {
            _vehicleServiceMock = new Mock<IVehicleService>();
            _controller = new VehicleController(_vehicleServiceMock.Object);
        }

        [Fact]
        public void GetAllVehicles_ReturnsOkResult_WithList()   //Just testing if this method returns an Ok Result with a list of vehicles, not testing the actual data
        {
            // Arrange
            var vehicles = new List<VehicleDTO>
            {
                new VehicleDTO(),
                new VehicleDTO()
            };

            _vehicleServiceMock.Setup(s => s.GetAllVehicles())
                .Returns(vehicles);

            // Act
            var result = _controller.GetAllVehicles();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<VehicleDTO>>(okResult.Value);

            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetVehicleById_ReturnsNotFound_WhenVehicleDoesNotExist()    // Just testing if this method returns a NotFoundResult when the vehicle does not exist, not testing the actual data
        {
            // Arrange
            _vehicleServiceMock.Setup(s => s.GetVehicleById(It.IsAny<int>()))
                .Returns((VehicleDTO)null);

            // Act
            var result = _controller.GetVehicleById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
