namespace SapiensDataAPI.Models
{
	public class ReceiptProduct
	{
		public int ReceiptProductId { get; set; }

		public int ReceiptId { get; set; }
		
		public int ProductId { get; set; }

		public decimal Discount { get; set; }

		public virtual Receipt? Receipt { get; set; }

		public virtual Product? Product { get; set; }
	}
}
