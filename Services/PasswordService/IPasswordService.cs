namespace GAS_LATIHAN_ASP.Services.PasswordService
{
    public interface IPasswordService
    {
        string Hash(string password);
        Task<bool> CheckPassword(Guid id, string password);
    }
}
