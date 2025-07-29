using GameStore.Application.Dtos.Authorization.Role.Create;
using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.Role.Update;
using GameStore.Application.Interfaces.Auth;
using GameStore.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //[Authorize(Policy = "ManageRoles")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        //[Authorize(Policy = "ManageRoles")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(Guid id)
        {
            var role = await _roleService.GetById(id);
            return Ok(role);
        }

        //[Authorize(Policy = "ManageRoles")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            bool deleted = await _roleService.DeleteRoleAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpGet("permissions")]
        //[Authorize(Policy = "ManageRoles")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _roleService.GetAllPermissionsAsync();
            return Ok(permissions);
        }
        [HttpGet("{id:guid}/permissions")]
        //[Authorize(Policy = "ManageRoles")]
        public async Task<IActionResult> GetRolePermissions(Guid id)
        {
            var permissions = await _roleService.GetRolePermissionsAsync(id);

            if (permissions == null)
            {
                return NotFound($"Role not found: {id}");
            }

            return Ok(permissions);
        }
        [HttpPost]
        //[Authorize(Policy = "ManageRoles")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequestDto request)
        {
            var result = await _roleService.AddRoleAsync(request);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetAllRoles),
                    new { id = result.RoleId },
                    new { id = result.RoleId });
            }

            return BadRequest(result.Error);
        }

        [HttpPut]
        //[Authorize(Policy = "ManageRoles")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequestDto request)
        {
            var result = await _roleService.UpdateRoleAsync(request);

            if (result.Success)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }
    }
}
