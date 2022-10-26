using AutoMapper;
using GAS_LATIHAN_ASP.Models.DAO;
using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Repositories.RoleRepository;

namespace GAS_LATIHAN_ASP.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoleDTO?> CreateRole(RoleDTO role)
        {
            var newRole = _mapper.Map<RoleDAO>(role);
            var result = await _repository.CreateRole(newRole);
            var response = _mapper.Map<RoleDTO>(result);

            return response ?? null;
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            return await _repository.DeleteRole(id);
        }

        public async Task<IList<RoleDTO>?> GetAllRoles()
        {
            var result = await _repository.GetAllRoles();
            var response = _mapper.Map<IList<RoleDTO>>(result);

            return response ?? null;
        }

        public async Task<RoleDTO?> GetRole(Guid id)
        {
            var result = await _repository.GetRole(id);
            var response = _mapper.Map<RoleDTO>(result);

            return response ?? null;
        }

        public async Task<RoleDTO?> UpdateRole(Guid id, RoleDTO role)
        {
            var existingUser = await _repository.GetRole(id);
            if (existingUser == null) return null;

            existingUser.Name = role.Name;
            existingUser.IsActive = role.IsActive;

            var result = await _repository.UpdateRole(existingUser);
            var response = _mapper.Map<RoleDTO>(result);
            return response ?? null;
        }
    }
}
