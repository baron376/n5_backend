using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public interface IRequestPermissionService
    {
        Task<PermissionResultModel> RequestPermissionAsync(PermissionModel permissionModel);
    }
}
