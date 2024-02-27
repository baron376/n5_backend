using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public interface IGetPermissionsService
    {
        Task<PermissionModel> GetPermissionByIdAsync(int id);
        Task<IEnumerable<PermissionModel>> GetPermissionsAsync();
    }
}
