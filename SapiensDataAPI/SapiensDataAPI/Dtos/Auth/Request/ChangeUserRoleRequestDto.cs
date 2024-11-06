namespace SapiensDataAPI.Dtos.Auth.Request
{
    public class ChangeUserRoleRequestDto
    {
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}