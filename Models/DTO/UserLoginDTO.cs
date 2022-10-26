namespace GAS_LATIHAN_ASP.Models.DTO
{
    public class RequestLoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ResponseLoginUser
    {
        public string Token { get; set; }
        public Guid UserID { get; set; }
    }

    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
