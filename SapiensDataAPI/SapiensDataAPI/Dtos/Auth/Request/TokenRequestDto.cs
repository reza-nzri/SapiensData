namespace SapiensDataAPI.Dtos.Auth.Request
{
    public class TokenRequestDto
    {
		public required string RefreshToken { get; set; } = string.Empty;  // Refresh token for generating a new JWT
		public required string Token { get; set; }
    }
}