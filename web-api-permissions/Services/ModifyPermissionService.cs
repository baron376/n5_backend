using web_api_permissions.Infrastructure.Repositories;
using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public class ModifyPermissionService : IModifyPermissionService
    {
        private readonly PermisoRepository _permissionRepository;

        public ModifyPermissionService(PermisoRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<bool> UpdatePermissionAsync(int permissionId, PermissionModel modifiedPermission)
        {
            var existingPermission = await _permissionRepository.GetByIdAsync(permissionId);
            if (existingPermission == null)
            {
                return false;
            }
            
            existingPermission.NombreEmpleado = modifiedPermission.NombreEmpleado;
            existingPermission.ApellidoEmpleado = modifiedPermission.ApellidoEmpleado;
            existingPermission.TipoPermisoId = modifiedPermission.TipoPermisoId;
            existingPermission.FechaPermiso = modifiedPermission.FechaPermiso;

            var result = await _permissionRepository.UpdateAsync(existingPermission);
            return result;
        }
    }
}
