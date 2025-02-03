namespace SapiensDataAPI.Dtos.Auth.Response
{
    public class RefreshTokenResponseDto
    {
        public string NewToken { get; set; } = string.Empty;  // New JWT token
        public DateTime NewExpiration { get; set; }            // New token expiration date
        public required bool IsValid { get; set; }
		public string ErrorMessage { get; set; } = string.Empty;
        public List<ClaimDto> Claims { get; set; } = [];
    }
}