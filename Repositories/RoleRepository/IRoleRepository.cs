using GAS_LATIHAN_ASP.Models.DAO;

namespace GAS_LATIHAN_ASP.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<IList<RoleDAO>?> GetAllRoles();
        Task<RoleDAO?> GetRole(Guid id);
        Task<RoleDAO?> CreateRole(RoleDAO role);
        Task<RoleDAO?> UpdateRole(RoleDAO role);
        Task<bool> DeleteRole(Guid id);
    }
}
