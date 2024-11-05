using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? FullName { get; set; }

    public string? ShortName { get; set; }

    public string? StoreDescription { get; set; }

    public string? UserDescription { get; set; }

    public int? Quantity { get; set; }

    public int? QUnit { get; set; }

    public int? ItemsPerPackage { get; set; }

    public int? IppUnit { get; set; }

    public decimal? InlineTotalWeight { get; set; }

    public decimal? WeightPerUnit { get; set; }

    public int? WUnit { get; set; }

    public decimal? InlineTotalVolume { get; set; }

    public decimal? VolumePerUnit { get; set; }

    public int? VUnit { get; set; }

    public decimal? InlineTotalPrice { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UpUnit { get; set; }

    public decimal? VatRate { get; set; }

    public bool? IsBio { get; set; }

    public string? Code { get; set; }

    public int? CategoryId { get; set; }

    public string? Brand { get; set; }

    public string? OriginCountry { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? TaxCode { get; set; }

    public virtual UnitType? IppUnitNavigation { get; set; }

    public virtual UnitType? QUnitNavigation { get; set; }

    public virtual UnitType? UpUnitNavigation { get; set; }

    public virtual UnitType? VUnitNavigation { get; set; }

    public virtual UnitType? WUnitNavigation { get; set; }
}
