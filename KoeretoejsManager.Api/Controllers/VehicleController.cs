using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models.HelperModels;
using KoeretoejsManager.Shared.DTOs;
using KoeretoejsManager.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoeretoejsManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("driverlicense")]
        [AllowAnonymous]
        public ActionResult<List<VehicleDTO>> GetVehiclesByDriversLicense([FromBody] List<DrivingLicenseType> request)
        {
            var vehicles = _vehicleService.GetAllVehiclesByDriversLicense(request);

            return Ok(vehicles);
        }
    }
}
