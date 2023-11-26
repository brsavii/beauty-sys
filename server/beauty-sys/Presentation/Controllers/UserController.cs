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

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUser(CreateUserRequest createCustomerRequest)
        {
            try
            {
                await _userService.SaveUser(createCustomerRequest);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            try
            {
                await _userService.UpdateUser(id, updateUserRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers(int currentPage, int takeQuantity = 10)
        {
            try
            {
                return Ok(_userService.GetUsers(currentPage, takeQuantity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("LogIn")]
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
