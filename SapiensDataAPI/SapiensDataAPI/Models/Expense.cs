using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Expense
{
    public required int ExpenseId { get; set; }

    public required string UserId { get; set; }

    public string? SourceType { get; set; }

    public string? SourceUserId { get; set; }

    public int? SourceCompanyId { get; set; }

    public string? SourceFirstName { get; set; }

    public string? SourceLastName { get; set; }

    public string? SourceCompanyName { get; set; }

    public DateOnly ExpenseDate { get; set; }

    public int? ExpenseCategoryId { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public string? Currency { get; set; }

    public int? PaymentMethodId { get; set; }

    public string? PaymentStatus { get; set; }

    public int? ReceiptId { get; set; }

    public int? TaxRateId { get; set; }

    public int FrequencyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastUpdatedAt { get; set; }

    public virtual ExpenseCategory? ExpenseCategory { get; set; }

    public virtual Frequency Frequency { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual Receipt? Receipt { get; set; }

    public virtual Company? SourceCompany { get; set; }

    public virtual ApplicationUserModel? SourceUser { get; set; }

    public virtual TaxRate? TaxRate { get; set; }

    public virtual ApplicationUserModel User { get; set; } = null!;
}
