using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Street { get; set; }

    public string? HouseNumber { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();

    public virtual ICollection<StoreAddress> StoreAddresses { get; set; } = new List<StoreAddress>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
