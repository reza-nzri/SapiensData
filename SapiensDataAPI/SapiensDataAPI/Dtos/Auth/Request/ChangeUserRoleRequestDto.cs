namespace SapiensDataAPI.Dtos.Auth.Request
{
    public class ChangeUserRoleRequestDto
    {
        public required string Username { get; set; }
        public required string RoleName { get; set; }
    }
}