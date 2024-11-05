using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class BankAccount
{
    public int AccountId { get; set; }

    public int UserId { get; set; }

    public int BankId { get; set; }

    public string? AccountNumber { get; set; }

    public string? AccountType { get; set; }

    public string? Iban { get; set; }

    public string? Currency { get; set; }

    public string? ApiAccessToken { get; set; }

    public decimal? AccountBalance { get; set; }

    public DateTime? LastSyncedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Bank Bank { get; set; } = null!;

    public virtual ICollection<BankTransaction> BankTransactions { get; set; } = new List<BankTransaction>();

    public virtual User User { get; set; } = null!;
}
