using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class ReceiptTaxDetail
{
    public int ReceiptTaxDetailId { get; set; }

    public int ReceiptId { get; set; }

    public int TaxRateId { get; set; }

    public decimal? NetSalesAmount { get; set; }

    public decimal? VatAmount { get; set; }

    public virtual Receipt Receipt { get; set; } = null!;

    public virtual TaxRate TaxRate { get; set; } = null!;
}
