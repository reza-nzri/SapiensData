using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class CompanyAddress
{
    public int CompanyAddressId { get; set; }

    public int? CompanyId { get; set; }

    public int? AddressId { get; set; }

    public bool? IsDefault { get; set; }

    public string? AddressType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Company? Company { get; set; }
}
