namespace SoftwareManagementAPI.Dtos.Auth
{
    public class AuthResult
    {
        public bool Success { get; set; }                       // Indicates if the operation was successful
        public string Message { get; set; } = string.Empty;    // Message about the result of the operation
    }
}