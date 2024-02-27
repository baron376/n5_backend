using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public class RequestPermissionService : IRequestPermissionService
    {
        public async Task<PermissionResultModel> RequestPermissionAsync(PermissionModel permissionModel)
        {
            
            var result = new PermissionResultModel
            {
                Success = true,
                Message = "Permission requested successfully"
            };

            return result;
        }
    }
}
