using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models.HelperModels;
using KoeretoejsManager.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KoeretoejsManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all-user-ids")]
        [AllowAnonymous]
        public ActionResult<List<UserIdDTO>> GetAllUserIds()
        {
            var userIds = _userService.GetAllUserIds();
            return Ok(userIds);
        }
    }
}

