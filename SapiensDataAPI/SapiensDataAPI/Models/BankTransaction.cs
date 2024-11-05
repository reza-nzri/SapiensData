using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class BankTransaction
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string? TransactionType { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public decimal? BalanceAfter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual BankAccount Account { get; set; } = null!;
}
