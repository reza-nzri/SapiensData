using SapiensDataAPI.Models;

namespace SapiensDataAPI.Dtos.Receipt.Request
{
	public class ReceiptDto
	{
		public DateTime? BuyDatetime { get; set; }

		public string? TraceNumber { get; set; }

		public decimal? TotalAmount { get; set; }

		public decimal? CashbackAmount { get; set; }

		public string? Currency { get; set; }

		public string? FullNamePaymentMethod { get; set; }

		public string? Iban { get; set; }

		public string? ReceiptImagePath { get; set; }

		public DateTime UploadDate { get; set; } = DateTime.UtcNow;

		public string? UserId { get; set; }
	}
}
