namespace SoftwareManagementAPI.Dtos.Auth.Request
{
    public class ChangeUserRoleRequestDto
    {
        public string Username { get; set; }
        public string NewRole { get; set; }
    }
}