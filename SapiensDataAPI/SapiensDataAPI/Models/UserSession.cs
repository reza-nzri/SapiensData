using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class UserSession
{
    public int SessionId { get; set; }

    public int UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public string? IpAddress { get; set; }

    public string? Device { get; set; }

    public string? Browser { get; set; }

    public string? OperatingSystem { get; set; }

    public string? SessionToken { get; set; }

    public bool? IsActive { get; set; }

    public string? Location { get; set; }

    public int? LoginAttempts { get; set; }

    public int? FailedLoginAttempts { get; set; }

    public int? SessionDuration { get; set; }

    public virtual User User { get; set; } = null!;
}
