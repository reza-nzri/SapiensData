namespace SapiensDataAPI.Dtos.Auth.Response
{
    public class RegisterResponseDto
    {
        public string Message { get; set; } = "Registration successful.";  // Success message
        public string Username { get; set; } = string.Empty;              // Registered username
    }
}