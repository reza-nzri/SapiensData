using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Saving
{
    public int SavingsId { get; set; }

    public int UserId { get; set; }

    public string SavingsGoal { get; set; } = null!;

    public decimal TargetAmount { get; set; }

    public decimal? SavedAmount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? TargetDate { get; set; }

    public int? FrequencyId { get; set; }

    public decimal? ContributionAmount { get; set; }

    public decimal? InterestRate { get; set; }

    public decimal? AccumulatedInterest { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime? LastUpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Frequency? Frequency { get; set; }

    public virtual User User { get; set; } = null!;
}
