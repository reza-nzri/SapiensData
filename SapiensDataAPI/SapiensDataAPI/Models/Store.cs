using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? Name { get; set; }

    public string? BrandName { get; set; }

    public string? TaxId { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<StoreAddress> StoreAddresses { get; set; } = new List<StoreAddress>();
}
