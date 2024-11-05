using Microsoft.AspNetCore.Identity;

namespace SapiensDataAPI.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}