using System.ComponentModel.DataAnnotations.Schema;

namespace SapiensDataAPI.Models
{
    public class RefreshTokenModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
        public string? JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUserModel User { get; set; } = default!; // Ensure it's not null when setting the user
    }
}