using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAS_LATIHAN_ASP.Models.DAO.User
{
    public class UserDAO : BaseEntity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid RoleID { get; set; }

    }
}
