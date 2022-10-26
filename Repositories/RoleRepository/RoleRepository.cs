using GAS_LATIHAN_ASP.Models;
using GAS_LATIHAN_ASP.Models.DAO;
using Microsoft.EntityFrameworkCore;

namespace GAS_LATIHAN_ASP.Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BEDBContext _dbContext;

        public RoleRepository(BEDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoleDAO?> CreateRole(RoleDAO role)
        {
            await _dbContext.Roles.AddAsync(role);

            var menuAccessData = new MenuAccessDAO
            {
                RoleID = role.ID
            };
            await _dbContext.MenuAccess.AddAsync(menuAccessData);

            var result = await _dbContext.SaveChangesAsync() == 1;
            return result ? role : null;
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            var role = await GetRole(id);
            if (role == null) return false;

            _dbContext.Roles.Remove(role);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result;
        }

        public async Task<IList<RoleDAO>?> GetAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<RoleDAO?> GetRole(Guid id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task<RoleDAO?> UpdateRole(RoleDAO role)
        {
            _dbContext.Roles.Update(role);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result ? role : null;
        }
    }
}
