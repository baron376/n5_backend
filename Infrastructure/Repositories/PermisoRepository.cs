using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using web_api_permissions;


using web_api_permissions.Domain.Entities;

namespace web_api_permissions.Infrastructure.Repositories
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly PermissionsDbContext _dbContext;

        public PermisoRepository(PermissionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permiso> GetByIdAsync(int id)
        {
            return await _dbContext.Permiso.FindAsync(id);
        }

        public async Task<IEnumerable<Permiso>> GetAllAsync()
        {
            return await _dbContext.Permiso.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Permiso permission)
        {
            _dbContext.Permiso.Update(permission);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
