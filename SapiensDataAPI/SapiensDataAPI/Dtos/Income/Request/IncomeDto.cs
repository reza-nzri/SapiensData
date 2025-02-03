namespace SapiensDataAPI.Dtos.Income.Request
{
	public class IncomeDto
	{
		public required string UserId { get; set; }

		public DateOnly IncomeDate { get; set; }

		public string? SourceUserId { get; set; }

		public string? SourceName { get; set; }

		public string? Description { get; set; }

		public decimal? GrossAmount { get; set; }

		public decimal? TaxAmount { get; set; }

		public decimal? NetAmount { get; set; }

		public bool? IsRecurring { get; set; }

		public int FrequencyId { get; set; }

		public string? PayerName { get; set; }
	}
}