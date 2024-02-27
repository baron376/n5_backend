using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public interface IModifyPermissionService
    {
        Task<bool> UpdatePermissionAsync(int id, PermissionModel permissionModel);
    }
}
