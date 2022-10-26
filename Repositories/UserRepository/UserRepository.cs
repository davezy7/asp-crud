using GAS_LATIHAN_ASP.Models;
using GAS_LATIHAN_ASP.Models.DAO.User;
using GAS_LATIHAN_ASP.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GAS_LATIHAN_ASP.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly BEDBContext _dbContext;

        public UserRepository(BEDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<UserDAO>?> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserDAO?> GetUser(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<UserDAO?> CreateUser(UserDAO user)
        {
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync() == 1;
            return result ? user : null;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return false;

            _dbContext.Users.Remove(user);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result;
        }

        public async Task<UserDAO?> UpdateUser(UserDAO user)
        {
            var dbUser = await GetUser(user.ID);
            if (dbUser == null) return null;


            _dbContext.Users.Update(user);
            var result = await _dbContext.SaveChangesAsync() == 1;

            return result ? dbUser : null;
        }

        public async Task<UserDAO?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null) return null;

            return user;
        }

        public async Task<string> GetUserPassword(Guid id)
        {
            var result = await _dbContext.Users.FindAsync(id);
            if (result == null) return string.Empty;

            return result.Password;
        }
    }
}
