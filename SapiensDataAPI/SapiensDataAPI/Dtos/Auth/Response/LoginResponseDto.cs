namespace SapiensDataAPI.Dtos.Auth.Response
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;         // JWT token
        public DateTime Expiration { get; set; }                 // Token expiration date
    }
}