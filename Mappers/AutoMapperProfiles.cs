using AutoMapper;
using GAS_LATIHAN_ASP.Models.DAO;
using GAS_LATIHAN_ASP.Models.DAO.User;
using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User Maps
            CreateMap<RequestCreateUser, UserDAO>();
            CreateMap<RequestUpdateUser, UserDAO>();
            CreateMap<UserDAO, ResponseCreateUser>();
            CreateMap<UserDAO, ResponseUpdateUser>();
            CreateMap<UserDAO, ResponseListUser>();
            CreateMap<UserDAO, ResponseUser>();

            // Role Maps
            CreateMap<RoleDTO, RoleDAO>();
            CreateMap<RoleDAO, RoleDTO>();
            CreateMap<RequestCreateRole, RoleDTO>();
            CreateMap<RequestUpdateRole, RoleDTO>();

            // Menu Maps
            CreateMap<RequestCreateUpdateMenu, MenuDAO>();
            CreateMap<MenuDAO, ResponseMenu>();
        }
    }
}
