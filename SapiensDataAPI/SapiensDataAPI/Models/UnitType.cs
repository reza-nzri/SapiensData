using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class UnitType
{
    public int UnitId { get; set; }

    public string? UnitName { get; set; }

    public string? UnitType1 { get; set; }

    public virtual ICollection<Product> ProductIppUnitNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductQUnitNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUpUnitNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductVUnitNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductWUnitNavigations { get; set; } = new List<Product>();
}
