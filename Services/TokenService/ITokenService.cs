using GAS_LATIHAN_ASP.Models.DTO;

namespace GAS_LATIHAN_ASP.Services.TokenService
{
    public interface ITokenService
    {
        ResponseLoginUser GenerateUserToken(Guid id, string email);
    }
}
