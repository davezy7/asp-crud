using GAS_LATIHAN_ASP.Repositories.UserRepository;
using System.Security.Cryptography;

namespace GAS_LATIHAN_ASP.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly int _defaultIteration = 100000;
        private readonly int _saltSize = 16;
        private readonly int _keySize = 32;
        private readonly IUserRepository _userRepository;

        public PasswordService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckPassword(Guid id, string password)
        {
            var userPassword = await _userRepository.GetUserPassword(id);
            if (userPassword == string.Empty) return false;

            var parts = userPassword.Split('.');
            if (parts.Length != 4) throw new FormatException("Unexpected hash format");

            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using var algoritm = new Rfc2898DeriveBytes(password, salt, _defaultIteration);
            var keyToCheck = algoritm.GetBytes(_keySize);
            return keyToCheck.SequenceEqual(key);
        }

        public string Hash(string password)
        {
            using var algoritm = new Rfc2898DeriveBytes(password, saltSize: _saltSize, iterations: _defaultIteration);
            var key = Convert.ToBase64String(algoritm.GetBytes(_keySize));
            var salt = Convert.ToBase64String(algoritm.Salt);

            return $"mas.{salt}.{key}.raden";
        }
    }
}
