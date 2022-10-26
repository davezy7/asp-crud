using AutoMapper;
using GAS_LATIHAN_ASP.Models.DAO;
using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Repositories.MenuRepository;

namespace GAS_LATIHAN_ASP.Services.MenuService
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }
        public async Task<ResponseMenu?> CreateMenu(RequestCreateUpdateMenu menu)
        {
            var newMenu = _mapper.Map<MenuDAO>(menu);
            var result = await _menuRepository.CreateMenu(newMenu);
            var response = _mapper.Map<ResponseMenu>(result);

            return response ?? null;
        }

        public async Task<bool> DeleteMenu(Guid id)
        {
            var existingMenu = await _menuRepository.GetMenu(id);
            if (existingMenu == null) return false;
            var result = _mapper.Map<MenuDAO>(existingMenu);
            return result == null;
        }

        public async Task<IList<ResponseMenu>?> GetAllMenus()
        {
            var result = await _menuRepository.GetAllMenus();
            if (result == null) return null;

            var response = _mapper.Map<IList<ResponseMenu>>(result);
            return response;
        }

        public async Task<ResponseMenu?> GetMenu(Guid id)
        {
            var existingMenu = await _menuRepository.GetMenu(id);
            if (existingMenu == null) return null;

            var result = _mapper.Map<ResponseMenu>(existingMenu);
            return result;
        }

        public async Task<ResponseMenu?> UpdateMenu(Guid id, RequestCreateUpdateMenu menu)
        {
            var existingMenu = await _menuRepository.GetMenu(id);
            if (existingMenu == null) return null;

            existingMenu.Label = menu.Label;
            existingMenu.URL = menu.URL;

            var result = await _menuRepository.UpdateMenu(existingMenu);
            var response = _mapper.Map<ResponseMenu>(result);

            return response ?? null;
        }
    }
}
