using System.Collections.Generic;
using System.Threading.Tasks;
using web_api_permissions.Domain.Entities;

namespace web_api_permissions.Infrastructure.Repositories
{
    public interface IPermisoRepository
    {
        Task<Permiso> GetByIdAsync(int id);
        Task<IEnumerable<Permiso>> GetAllAsync();
        Task<bool> UpdateAsync(Permiso permission);
    }
}
