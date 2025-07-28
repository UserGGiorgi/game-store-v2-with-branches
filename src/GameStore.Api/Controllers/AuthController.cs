using GameStore.Application.Dtos.Authorization.Permission;
using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Dtos.Authorization.User.Create;
using GameStore.Application.Dtos.Authorization.User.Update;
using GameStore.Application.Dtos.User.AuthDTOs;
using GameStore.Application.Interfaces.Auth;
using GameStore.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccessService _accessService;
        private readonly IUserService _userService;

        public AuthController(
            IAuthService authService,
            IAccessService accessService,
            IUserService userService)
        {
            _authService = authService;
            _accessService = accessService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }
        [Authorize]
        [HttpPost("access")]
        public async Task<IActionResult> CheckAccess([FromBody] AccessCheckRequestDto request)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized();

            var hasAccess = await _accessService.CheckAccessAsync(userEmail, request.TargetPage, request.TargetId);

            return hasAccess ? Ok() : Forbid();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && !string.Equals(currentUserEmail, id, StringComparison.OrdinalIgnoreCase))
                return Forbid();

            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (string.Equals(currentUserEmail, id, StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Cannot delete your own account");
                }

                var success = await _userService.DeleteUserByIdAsync(id);
                return success ? NoContent() : NotFound();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, ex.Message);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {
            var result = await _userService.CreateUserAsync(request);

            if (result.Success)
            {
                return CreatedAtAction(
                    nameof(GetUserById),
                    new { id = result.Email },
                    new { email = result.Email }
                );
            }

            return BadRequest(result.Error);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto request)
        {
            var result = await _userService.UpdateUserAsync(request);

            if (result.Success)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }
        [HttpGet("{id:guid}/roles")]
        public async Task<IActionResult> GetUserRoles(Guid id)
        {
            var roles = await _userService.GetUserRolesAsync(id);

            if (roles == null)
            {
                return NotFound($"User not found: {id}");
            }

            return Ok(roles);
        }
    }
}
