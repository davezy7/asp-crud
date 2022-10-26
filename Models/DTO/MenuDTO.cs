namespace GAS_LATIHAN_ASP.Models.DTO
{
    public class ResponseMenu
    {
        public Guid ID { get; set; }
        public string? Label { get; set; }
        public string? URL { get; set; }
    }

    public class RequestCreateUpdateMenu
    {
        public string? Label { get; set; }
        public string? URL { get; set; }
    }
}
