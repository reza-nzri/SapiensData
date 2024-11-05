using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();

    public virtual ICollection<ReceiptPayment> ReceiptPayments { get; set; } = new List<ReceiptPayment>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
