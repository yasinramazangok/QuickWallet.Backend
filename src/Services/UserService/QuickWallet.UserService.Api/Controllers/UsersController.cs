using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickWallet.UserService.Application.Contracts.DTOs;
using QuickWallet.UserService.Application.Contracts.Requests;
using QuickWallet.UserService.Application.Interfaces;

namespace QuickWallet.UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                var user = await _userService.RegisterAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
