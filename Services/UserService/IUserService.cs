using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Services.UserService
{
    public interface IUserService
    {
        Task<IList<ResponseListUser>> GetAllUsers();
        Task<ResponseUser> GetUser(Guid id);
        Task<ResponseCreateUser> CreateUser(RequestCreateUser user);
        Task<ResponseUpdateUser> UpdateUser(Guid id, RequestUpdateUser user);
        Task<bool> DeleteUser(Guid id);
        Task<ResponseUser?> GetUserByEmail(string email);
        Task<bool> CheckExistingUserByEmail(string email);
    }
}
