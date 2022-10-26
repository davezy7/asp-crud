using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Services.RoleService
{
    public interface IRoleService
    {
        Task<IList<RoleDTO>?> GetAllRoles();
        Task<RoleDTO?> GetRole(Guid id);
        Task<RoleDTO?> CreateRole(RoleDTO role);
        Task<RoleDTO?> UpdateRole(Guid id, RoleDTO role);
        Task<bool> DeleteRole(Guid id);
    }
}
