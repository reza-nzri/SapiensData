using SapiensDataAPI.Models;

namespace SapiensDataAPI.Dtos.Receipt.JSON
{
	//public class ReceiptVailidation
	//{
	//	public Store? Store { get; set; }

	//	public ICollection<Product>? Products { get; set; }

	//	public Models.Receipt? Receipt { get; set; }

	//	public TaxRate? TaxRate { get; set; }

	//	public ReceiptTaxDetail? ReceiptTaxDetail { get; set; }
	//}

	public class StoreV
	{
		public string Name { get; set; } = string.Empty;
		public string BrandName { get; set; } = string.Empty;
		public string TaxId { get; set; } = string.Empty;
		public string Street { get; set; } = string.Empty;
		public string HouseNumber { get; set; } = string.Empty;
		public string PostalCode { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string Country { get; set; } = string.Empty;
		public string AddressType { get; set; } = string.Empty;
	}

	public class ProductV
	{
		public string FullName { get; set; } = string.Empty;
		public string ShortName { get; set; } = string.Empty;
		public string StoreDescription { get; set; } = string.Empty;
		public string UserDescription { get; set; } = string.Empty;
		public string Quantity { get; set; } = string.Empty;
		public string QUnitName { get; set; } = string.Empty;
		public string ItemsPerPackage { get; set; } = string.Empty;
		public string IppUnitName { get; set; } = string.Empty;
		public string InlineTotalWeight { get; set; } = string.Empty;
		public string WeightPerUnit { get; set; } = string.Empty;
		public string WUnitName { get; set; } = string.Empty;
		public string InlineTotalVolume { get; set; } = string.Empty;
		public string VolumePerUnit { get; set; } = string.Empty;
		public string VUnitName { get; set; } = string.Empty;
		public string InlineTotalPrice { get; set; } = string.Empty;
		public string UnitPrice { get; set; } = string.Empty;
		public string UpUnitName { get; set; } = string.Empty;
		public string VatRate { get; set; } = string.Empty;
		public string IsBio { get; set; } = string.Empty;
		public string Code { get; set; } = string.Empty;
		public string CategoryName { get; set; } = string.Empty;
		public string Brand { get; set; } = string.Empty;
		public string OriginCountry { get; set; } = string.Empty;
		public string ExpirationDate { get; set; } = string.Empty;
		public string TaxCode { get; set; } = string.Empty;
	}

	public class ReceiptV
	{
		public string BuyDatetime { get; set; } = string.Empty;
		public string TraceNumber { get; set; } = string.Empty;
		public string TotalAmount { get; set; } = string.Empty;
		public string CashbackAmount { get; set; } = string.Empty;
		public string Currency { get; set; } = string.Empty;
		public string TotalLoyalty { get; set; } = string.Empty;
		public string FullNamePaymentMethod { get; set; } = string.Empty;
		public string PaymentMethodName { get; set; } = string.Empty;
		public string ReceiptPaymentAmount { get; set; } = string.Empty;
		public string Iban { get; set; } = string.Empty;
	}

	public class TaxRateV
	{
		public string TaxCode { get; set; } = string.Empty;
		public string VatRate { get; set; } = string.Empty;
		public string NetAmount { get; set; } = string.Empty;
		public string VatAmount { get; set; } = string.Empty;
	}

	public class ReceiptTaxDetailV
	{
		public string NetSalesAmount { get; set; } = string.Empty;
		public string VatAmount { get; set; } = string.Empty;
	}

	public class ReceiptVailidation
	{
		public StoreV Store { get; set; } = new StoreV();
		public List<ProductV> Product { get; set; } = new List<ProductV>();
		public ReceiptV Receipt { get; set; } = new ReceiptV();
		public TaxRateV TaxRate { get; set; } = new TaxRateV();
		public ReceiptTaxDetailV ReceiptTaxDetail { get; set; } = new ReceiptTaxDetailV();
	}

}
