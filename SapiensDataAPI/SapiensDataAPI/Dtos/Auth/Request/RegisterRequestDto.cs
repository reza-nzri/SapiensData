namespace SapiensDataAPI.Dtos.Auth.Request
{
    public class RegisterRequestDto
    {
        public string Username { get; set; } = string.Empty;  // User's username
        public string Password { get; set; } = string.Empty;  // User's password
        public string Email { get; set; } = string.Empty;     // User's email address
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}