namespace SoftwareManagementAPI.Dtos.Auth.Request
{
    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;  // User's username
        public string Password { get; set; } = string.Empty;  // User's password
    }
}