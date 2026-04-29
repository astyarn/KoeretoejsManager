using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models.HelperModels;
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
        public IActionResult<List> GetVehiclesByDriversLicense([FromBody] )
        {
            
        }
    }
}
