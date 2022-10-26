namespace GAS_LATIHAN_ASP.Models.DAO
{
    public class MenuAccessDAO : BaseEntity
    {
        public Guid RoleID { get; set; }
        public Guid MenuID { get; set; }
        public bool CreateAccess { get; set; }
        public bool ReadAccess { get; set; }
        public bool UpdateAccess { get; set; }
        public bool DeleteAccess { get; set; }
    }
}
