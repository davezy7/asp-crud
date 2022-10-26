using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Services.MenuService
{
    public interface IMenuService
    {
        Task<IList<ResponseMenu>?> GetAllMenus();
        Task<ResponseMenu?> GetMenu(Guid id);
        Task<ResponseMenu?> CreateMenu(RequestCreateUpdateMenu menu);
        Task<ResponseMenu?> UpdateMenu(Guid id, RequestCreateUpdateMenu menu);
        Task<bool> DeleteMenu(Guid id);
    }
}
