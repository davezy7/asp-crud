namespace GAS_LATIHAN_ASP.Models.DTO
{
    public class ResponseUser
    {
        public Guid ID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleDTO? Role { get; set; }
    }

    public class ResponseListUser
    {
        public Guid ID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid RoleID { get; set; }
    }

    public class RequestCreateUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid RoleID { get; set; }
    }

    public class ResponseCreateUser
    {
        public Guid ID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleDTO? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class RequestUpdateUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid RoleID { get; set; }
    }

    public class ResponseUpdateUser
    {
        public Guid ID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleDTO? Role { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
