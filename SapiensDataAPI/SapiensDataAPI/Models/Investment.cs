using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Investment
{
    public int InvestmentId { get; set; }

    public int UserId { get; set; }

    public string? InvestmentType { get; set; }

    public decimal Amount { get; set; }

    public string? LoanedToUserId { get; set; }

    public int? LoanedToCompanyId { get; set; }

    public string? LoanedToFirstName { get; set; }

    public string? LoanedToLastName { get; set; }

    public DateOnly InvestmentDate { get; set; }

    public string? Description { get; set; }

    public decimal? InterestRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Company? LoanedToCompany { get; set; }

    public virtual ApplicationUserModel? LoanedToUser { get; set; }
}
