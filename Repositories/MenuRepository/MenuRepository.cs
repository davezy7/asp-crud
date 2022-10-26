using GAS_LATIHAN_ASP.Models;
using GAS_LATIHAN_ASP.Models.DAO;
using GAS_LATIHAN_ASP.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GAS_LATIHAN_ASP.Repositories.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BEDBContext _dbContext;
        public MenuRepository(BEDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuDAO?> CreateMenu(MenuDAO menu)
        {
            await _dbContext.Menus.AddAsync(menu);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result ? menu : null;
        }

        public async Task<bool> DeleteMenu(Guid id)
        {
            var menu = await GetMenu(id);
            if (menu == null) return false;

            _dbContext.Menus.Remove(menu);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result;
        }

        public async Task<IList<MenuDAO>?> GetAllMenus()
        {
            return await _dbContext.Menus.ToListAsync();
        }

        public async Task<MenuDAO?> GetMenu(Guid id)
        {
            var menu = await _dbContext.Menus.FindAsync(id);
            return menu ?? null;
        }

        public async Task<MenuDAO?> UpdateMenu(MenuDAO menu)
        {
            _dbContext.Menus.Update(menu);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result ? menu : null;
        }
    }
}
