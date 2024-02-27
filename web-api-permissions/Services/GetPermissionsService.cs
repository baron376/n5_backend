using web_api_permissions.Domain.Entities;
using web_api_permissions.Infrastructure.Repositories;
using web_api_permissions.Models;

namespace web_api_permissions.Services
{
    public class GetPermissionsService : IGetPermissionsService
    {
        private readonly IPermisoRepository _permisoRepository;

        public GetPermissionsService(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        public async Task<PermissionModel> GetPermissionByIdAsync(int id)
        {
            try
            {
                var permission = await _permisoRepository.GetByIdAsync(id);
                return MapPermisoToPermissionModel(permission); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving permission by ID: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<PermissionModel>> GetPermissionsAsync()
        {
            var permisos = await _permisoRepository.GetAllAsync();
            var permissionModels = permisos.Select(MapPermisoToPermissionModel);

            return permissionModels;
        }

        private PermissionModel MapPermisoToPermissionModel(Permiso permiso)
        {
            return new PermissionModel
            {
                Id = permiso.Id,
                NombreEmpleado = permiso.NombreEmpleado,
                ApellidoEmpleado = permiso.ApellidoEmpleado,
                TipoPermisoId = permiso.TipoPermisoId,
                FechaPermiso = permiso.FechaPermiso
            };
        }
    }

}
