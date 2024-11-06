using Microsoft.AspNetCore.Identity;

namespace SapiensDataAPI.Models
{
	public class ApplicationUserModel : IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;
		public string? MiddleName { get; set; }
		public string LastName { get; set; } = string.Empty;
		public string? Prefix { get; set; }
		public string? Suffix { get; set; }
		public string? Nickname { get; set; }
		public string? RecoveryEmail { get; set; }
		public string? AlternaiveEmail { get; set; }
		public string? RecoveryPhoneNumber { get; set; }
		public string? Gender { get; set; }
		public DateOnly? Birthday { get; set; }
		public string? ProfilePicturePath { get; set; }
		public string? CompanyName { get; set; }
		public string? JobTitle { get; set; }
		public string? Department { get; set; }
		public string? AppLanguage { get; set; }
		public string? Website { get; set; }
		public string? Linkedin { get; set; }
		public string? Facebook { get; set; }
		public string? Instagram { get; set; }
		public string? Twitter { get; set; }
		public string? Github { get; set; }
		public string? Youtube { get; set; }
		public string? Tiktok { get; set; }
		public string? Snapchat { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? LastLogin { get; set; }
		public string? Status { get; set; }
		public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
		public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
		public virtual ICollection<Expense> ExpenseSourceUsers { get; set; } = new List<Expense>();
		public virtual ICollection<Expense> ExpenseUsers { get; set; } = new List<Expense>();
		public virtual ICollection<Income> IncomeSourceUsers { get; set; } = new List<Income>();
		public virtual ICollection<Income> IncomeUsers { get; set; } = new List<Income>();
		public virtual ICollection<Investment> Investments { get; set; } = new List<Investment>();
		public virtual ICollection<Saving> Savings { get; set; } = new List<Saving>();
		public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
		public virtual ICollection<UserRelationship> UserRelationshipRelatedUsers { get; set; } = new List<UserRelationship>();
		public virtual ICollection<UserRelationship> UserRelationshipUsers { get; set; } = new List<UserRelationship>();
		public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
	}
}