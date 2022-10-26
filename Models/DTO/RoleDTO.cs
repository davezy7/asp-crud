namespace GAS_LATIHAN_ASP.Models.DTO
{
    public class RoleDTO
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class RequestCreateRole
    {
        public string Name { get; set; }
    }

    public class RequestUpdateRole
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
