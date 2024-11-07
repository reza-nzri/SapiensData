using SapiensDataAPI.Models;

namespace SapiensDataAPI.Dtos.Expense.Request
{
	public class ExpenseDto
	{
		public required string UserId { get; set; }

		public string? SourceUserId { get; set; }

		public string? SourceFirstName { get; set; }

		public string? SourceLastName { get; set; }

		public string? SourceCompanyName { get; set; }

		public DateOnly ExpenseDate { get; set; }

		public string? Description { get; set; }

		public decimal Amount { get; set; }

		public string? Currency { get; set; }

		public string? PaymentStatus { get; set; }

		public int FrequencyId { get; set; }
	}
}
