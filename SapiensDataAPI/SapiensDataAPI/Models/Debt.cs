using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Debt
{
    public int DebtId { get; set; }

    public int UserId { get; set; }

    public string? DebtType { get; set; }

    public decimal AmountOwed { get; set; }

    public decimal? InterestRate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? CreditorUserId { get; set; }

    public int? CreditorCompanyId { get; set; }

    public string? CreditorFirstName { get; set; }

    public string? CreditorLastName { get; set; }

    public string? CreditorCompanyName { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? Frequency { get; set; }

    public int? TimesRemaining { get; set; }

    public DateTime? NextReminder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Company? CreditorCompany { get; set; }

    public virtual ApplicationUserModel? CreditorUser { get; set; }
}
