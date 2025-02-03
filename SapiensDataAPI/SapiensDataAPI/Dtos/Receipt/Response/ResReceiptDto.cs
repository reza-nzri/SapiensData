using SapiensDataAPI.Dtos.Receipt.JSON;

namespace SapiensDataAPI.Dtos.Receipt.Response
{
	public class ResReceiptDto
	{
		public string FileName { get; set; } = string.Empty;

		public string ContentType { get; set; } = string.Empty;

		public DateTime? UploadDate { get; set; }

		public StoreV Store { get; set; } = new StoreV();
		public List<ProductV> Product { get; set; } = [];
		public ReceiptV Receipt { get; set; } = new ReceiptV();
		public List<TaxRateV> TaxRate { get; set; } = new List<TaxRateV>();
		public List<ReceiptTaxDetailV> ReceiptTaxDetail { get; set; } = new List<ReceiptTaxDetailV>();
		public string ImageData { get; set; } = string.Empty;
	}
}
