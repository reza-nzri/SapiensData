using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }

    public DateTime? BuyDatetime { get; set; }

    public string? TraceNumber { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? CashbackAmount { get; set; }

    public string? Currency { get; set; }

    public decimal? TotalLoyalty { get; set; }

    public string? FullNamePaymentMethod { get; set; }

    public string? Iban { get; set; }

    public string? ReceiptImagePath { get; set; }

    public string? UserId { get; set; }

    public DateTime? UploadDate { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual ICollection<ReceiptPayment> ReceiptPayments { get; set; } = new List<ReceiptPayment>();

    public virtual ICollection<ReceiptTaxDetail> ReceiptTaxDetails { get; set; } = new List<ReceiptTaxDetail>();

    public virtual Store? Store { get; set; }
    
    public virtual ApplicationUserModel? User { get; set; }

    public virtual ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();

	public virtual ICollection<ReceiptProduct> ReceiptProducts { get; set; } = [];
}
