using System.Text.Json.Serialization;

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
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;

		[JsonPropertyName("brand_name")]
		public string BrandName { get; set; } = string.Empty;

		[JsonPropertyName("tax_id")]
		public string TaxId { get; set; } = string.Empty;

		[JsonPropertyName("street")]
		public string Street { get; set; } = string.Empty;

		[JsonPropertyName("house_number")]
		public string HouseNumber { get; set; } = string.Empty;

		[JsonPropertyName("postal_code")]
		public string PostalCode { get; set; } = string.Empty;

		[JsonPropertyName("city")]
		public string City { get; set; } = string.Empty;

		[JsonPropertyName("state")]
		public string State { get; set; } = string.Empty;

		[JsonPropertyName("country")]
		public string Country { get; set; } = string.Empty;

		[JsonPropertyName("address_type")]
		public string AddressType { get; set; } = string.Empty;
	}

	public class ProductV
	{
		[JsonPropertyName("full_name")]
		public string FullName { get; set; } = string.Empty;

		[JsonPropertyName("short_name")]
		public string ShortName { get; set; } = string.Empty;

		[JsonPropertyName("store_description")]
		public string StoreDescription { get; set; } = string.Empty;

		[JsonPropertyName("user_description")]
		public string UserDescription { get; set; } = string.Empty;

		[JsonPropertyName("quantity")]
		public string Quantity { get; set; } = string.Empty;

		[JsonPropertyName("q_unit_name")]
		public string QUnitName { get; set; } = string.Empty;

		[JsonPropertyName("items_per_package")]
		public string ItemsPerPackage { get; set; } = string.Empty;

		[JsonPropertyName("ipp_unit_name")]
		public string IppUnitName { get; set; } = string.Empty;

		[JsonPropertyName("inline_total_weight")]
		public string InlineTotalWeight { get; set; } = string.Empty;

		[JsonPropertyName("weight_per_unit")]
		public string WeightPerUnit { get; set; } = string.Empty;

		[JsonPropertyName("w_unit_name")]
		public string WUnitName { get; set; } = string.Empty;

		[JsonPropertyName("inline_total_volume")]
		public string InlineTotalVolume { get; set; } = string.Empty;

		[JsonPropertyName("volume_per_unit")]
		public string VolumePerUnit { get; set; } = string.Empty;

		[JsonPropertyName("v_unit_name")]
		public string VUnitName { get; set; } = string.Empty;

		[JsonPropertyName("inline_total_price")]
		public string InlineTotalPrice { get; set; } = string.Empty;

		[JsonPropertyName("unit_price")]
		public string UnitPrice { get; set; } = string.Empty;

		[JsonPropertyName("up_unit_name")]
		public string UpUnitName { get; set; } = string.Empty;

		[JsonPropertyName("vat_rate")]
		public string VatRate { get; set; } = string.Empty;

		[JsonPropertyName("is_bio")]
		public string IsBio { get; set; } = string.Empty;

		[JsonPropertyName("code")]
		public string Code { get; set; } = string.Empty;

		[JsonPropertyName("category_name")]
		public string CategoryName { get; set; } = string.Empty;

		[JsonPropertyName("brand")]
		public string Brand { get; set; } = string.Empty;

		[JsonPropertyName("origin_country")]
		public string OriginCountry { get; set; } = string.Empty;

		[JsonPropertyName("expiration_date")]
		public string ExpirationDate { get; set; } = string.Empty;

		[JsonPropertyName("tax_code")]
		public string TaxCode { get; set; } = string.Empty;
	}

	public class ReceiptV
	{
		[JsonPropertyName("buy_datetime")]
		public DateTime BuyDatetime { get; set; } = DateTime.Now;

		[JsonPropertyName("trace_number")]
		public string TraceNumber { get; set; } = string.Empty;

		[JsonPropertyName("total_amount")]
		public string TotalAmount { get; set; } = string.Empty;

		[JsonPropertyName("cashback_amount")]
		public string CashbackAmount { get; set; } = string.Empty;

		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;

		[JsonPropertyName("total_loyalty")]
		public string TotalLoyalty { get; set; } = string.Empty;

		[JsonPropertyName("full_name_payment_method")]
		public string FullNamePaymentMethod { get; set; } = string.Empty;

		[JsonPropertyName("payment_method_name")]
		public string PaymentMethodName { get; set; } = string.Empty;

		[JsonPropertyName("receipt_payment_amount")]
		public string ReceiptPaymentAmount { get; set; } = string.Empty;

		[JsonPropertyName("iban")]
		public string Iban { get; set; } = string.Empty;
	}

	public class TaxRateV
	{
		[JsonPropertyName("tax_code")]
		public string TaxCode { get; set; } = string.Empty;

		[JsonPropertyName("vat_rate")]
		public string VatRate { get; set; } = string.Empty;

		[JsonPropertyName("net_amount")]
		public string NetAmount { get; set; } = string.Empty;

		[JsonPropertyName("vat_amount")]
		public string VatAmount { get; set; } = string.Empty;
	}

	public class ReceiptTaxDetailV
	{
		[JsonPropertyName("net_sales_amount")]
		public string NetSalesAmount { get; set; } = string.Empty;

		[JsonPropertyName("vat_amount")]
		public string VatAmount { get; set; } = string.Empty;
	}

	public class FileMetadataV
	{
		[JsonPropertyName("receipt_filename")]
		public string ReceiptFilename { get; set; } = string.Empty;
	}

	public class ReceiptVailidation
	{
		public FileMetadataV FileMetadata { get; set; } = new FileMetadataV();
		public StoreV Store { get; set; } = new StoreV();
		public List<ProductV> Product { get; set; } = [];
		public ReceiptV Receipt { get; set; } = new ReceiptV();
		public TaxRateV TaxRate { get; set; } = new TaxRateV();
		public ReceiptTaxDetailV ReceiptTaxDetail { get; set; } = new ReceiptTaxDetailV();
	}
}