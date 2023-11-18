using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("LogIn")]
        public IActionResult LogIn(LogInRequest logInRequest)
        {
            try
            {
                return Ok(_userService.LogIn(logInRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
