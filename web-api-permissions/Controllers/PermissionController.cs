using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_permissions.Models;
using web_api_permissions.Services;

namespace web_api_permissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IRequestPermissionService _requestPermissionService;
        private readonly IModifyPermissionService _modifyPermissionService;
        private readonly IGetPermissionsService _getPermissionsService;

        public PermissionController(IRequestPermissionService requestPermissionService, IModifyPermissionService modifyPermissionService, IGetPermissionsService getPermissionsService)
        {
            _requestPermissionService = requestPermissionService;
            _modifyPermissionService = modifyPermissionService;
            _getPermissionsService = getPermissionsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = await _getPermissionsService.GetPermissionByIdAsync(id);

                if (permission == null)
                {
                    return NotFound();
                }

                return Ok(permission);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the permission: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermissionAsync(int id, [FromBody] PermissionModel permissionModel)
        {
            try
            {
                var result = await _modifyPermissionService.UpdatePermissionAsync(id, permissionModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionsAsync()
        {
            var permissions = await _getPermissionsService.GetPermissionsAsync();

            if (permissions == null || !permissions.Any())
            {
                return NotFound();
            }

            return Ok(permissions);
        }
    }
}
