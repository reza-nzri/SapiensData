using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class UserRelationship
{
    public int RelationshipId { get; set; }

    public int UserId { get; set; }

    public int RelatedUserId { get; set; }

    public string? RelationshipType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User RelatedUser { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
