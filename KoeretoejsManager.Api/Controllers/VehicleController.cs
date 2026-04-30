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

        [HttpPost("search-by-drivers-license")]
        [AllowAnonymous]
        public ActionResult<List<VehicleSearchByDriverslicenseDTO>> SearchVehiclesByDriversLicense([FromBody] VehicleSearchDriversLicenseRequest request)
        {
            if (request == null || request.LicenseTypes == null || !request.LicenseTypes.Any())
            {
                return BadRequest("License types are required.");
            }

            var vehicles = _vehicleService.GetAllVehiclesByDriversLicense(request.LicenseTypes);

            return Ok(vehicles);
        }

        [HttpGet("all-vehicles")]
        [AllowAnonymous]
        public ActionResult<List<VehicleSearchByDriverslicenseDTO>> GetAllVehicles()
        {
            var vehicles = _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }
    }
}
