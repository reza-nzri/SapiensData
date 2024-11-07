using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class BankAccount
{
    public required int AccountId { get; set; }

    public required string UserId { get; set; }

    public required int BankId { get; set; }

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

    public virtual ApplicationUserModel User { get; set; } = null!;
}
