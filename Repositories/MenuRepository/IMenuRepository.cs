using GAS_LATIHAN_ASP.Models.DAO;
using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Repositories.MenuRepository
{
    public interface IMenuRepository
    {
        Task<IList<MenuDAO>?> GetAllMenus();
        Task<MenuDAO?> GetMenu(Guid id);
        Task<MenuDAO?> CreateMenu(MenuDAO menu);
        Task<MenuDAO?> UpdateMenu(MenuDAO menu);
        Task<bool> DeleteMenu(Guid id);
    }
}
