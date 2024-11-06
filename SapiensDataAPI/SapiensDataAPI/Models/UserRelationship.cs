using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class UserRelationship
{
    public int RelationshipId { get; set; }

    public string UserId { get; set; }

    public string RelatedUserId { get; set; }

    public string? RelationshipType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ApplicationUserModel RelatedUser { get; set; } = null!;

    public virtual ApplicationUserModel User { get; set; } = null!;
}
