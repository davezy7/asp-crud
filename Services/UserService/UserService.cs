using AutoMapper;
using GAS_LATIHAN_ASP.Models.DAO.User;
using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Repositories.RoleRepository;
using GAS_LATIHAN_ASP.Repositories.UserRepository;

namespace GAS_LATIHAN_ASP.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IList<ResponseListUser>> GetAllUsers()
        {
            var result = await _userRepository.GetAllUsers();
            var response = _mapper.Map<IList<ResponseListUser>>(result);

            return response;
        }

        public async Task<ResponseUser> GetUser(Guid id)
        {
            var result = await _userRepository.GetUser(id);
            var response = _mapper.Map<ResponseUser>(result);

            var userRole = await CheckIfRoleExists(result.RoleID);
            if (userRole == null) return null;

            response.Role = userRole;

            return response;
        }

        public async Task<ResponseCreateUser> CreateUser(RequestCreateUser user)
        {
            var userRole = await CheckIfRoleExists(user.RoleID);
            if (userRole == null) return null;

            var userDao = _mapper.Map<UserDAO>(user);
            var result = await _userRepository.CreateUser(userDao);
            var response = _mapper.Map<ResponseCreateUser>(result);
            response.Role = userRole;

            return response;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userRepository.DeleteUser(id);
        }


        public async Task<ResponseUpdateUser> UpdateUser(Guid id, RequestUpdateUser user)
        {
            var userDao = await _userRepository.GetUser(id);
            if (userDao == null) return null;

            if (await CheckIfRoleExists(id) == null) return null;

            userDao.FullName = user.FullName;
            userDao.PhoneNumber = user.PhoneNumber;
            userDao.Password = user.Password;
            userDao.RoleID = user.RoleID;

            var result = await _userRepository.UpdateUser(userDao);
            var response = _mapper.Map<ResponseUpdateUser>(result);

            return response;
        }

        /*
         * FOR INTERNAL USE ONLEH
         */
        public async Task<ResponseUser?> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null;

            var result = _mapper.Map<ResponseUser>(user);

            return result;

        }

        public async Task<bool> CheckExistingUserByEmail(string email)
        {
            var result = await _userRepository.GetUserByEmail(email);
            if (result != null) return true;

            return false;
        }

        private async Task<RoleDTO> CheckIfRoleExists(Guid roleId)
        {
            var existingRole = await _roleRepository.GetRole(roleId);
            if (existingRole == null) return null;
            var response = _mapper.Map<RoleDTO>(existingRole);
            return response;
        }
    }
}
