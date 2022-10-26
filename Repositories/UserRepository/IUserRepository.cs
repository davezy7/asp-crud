using GAS_LATIHAN_ASP.Models.DAO.User;

namespace GAS_LATIHAN_ASP.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IList<UserDAO>?> GetAllUsers();
        Task<UserDAO?> GetUser(Guid id);
        Task<UserDAO?> GetUserByEmail(string email);
        Task<UserDAO?> CreateUser(UserDAO user);
        Task<UserDAO?> UpdateUser(UserDAO user);
        Task<bool> DeleteUser(Guid id);
        Task<string> GetUserPassword(Guid id);
    }
}
