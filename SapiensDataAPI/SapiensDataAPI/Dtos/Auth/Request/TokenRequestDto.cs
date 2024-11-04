namespace SapiensDataAPI.Dtos.Auth.Request
{
    public class TokenRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;  // Refresh token for generating a new JWT
        public string Token { get; set; }
    }
}