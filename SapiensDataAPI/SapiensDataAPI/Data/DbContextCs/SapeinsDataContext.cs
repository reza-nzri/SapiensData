using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SapiensDataAPI.Models;

namespace SapiensDataAPI.Data.DbContextCs;

public partial class SapeinsDataContext : IdentityDbContext<ApplicationUserModel>
{
	public SapeinsDataContext()
	{
	}

	public SapeinsDataContext(DbContextOptions<SapeinsDataContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Address> Addresses { get; set; }

	public virtual DbSet<Bank> Banks { get; set; }

	public virtual DbSet<BankAccount> BankAccounts { get; set; }

	public virtual DbSet<BankTransaction> BankTransactions { get; set; }

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<Company> Companies { get; set; }

	public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }

	public virtual DbSet<Debt> Debts { get; set; }

	public virtual DbSet<Expense> Expenses { get; set; }

	public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

	public virtual DbSet<Frequency> Frequencies { get; set; }

	public virtual DbSet<Income> Incomes { get; set; }

	public virtual DbSet<IncomeCategory> IncomeCategories { get; set; }

	public virtual DbSet<Investment> Investments { get; set; }

	public virtual DbSet<Label> Labels { get; set; }

	public virtual DbSet<LabelAssignment> LabelAssignments { get; set; }

	public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<Receipt> Receipts { get; set; }

	public virtual DbSet<ReceiptPayment> ReceiptPayments { get; set; }

	public virtual DbSet<ReceiptTaxDetail> ReceiptTaxDetails { get; set; }

	public virtual DbSet<Saving> Savings { get; set; }

	public virtual DbSet<Store> Stores { get; set; }

	public virtual DbSet<StoreAddress> StoreAddresses { get; set; }

	public virtual DbSet<TaxRate> TaxRates { get; set; }

	public virtual DbSet<UnitType> UnitTypes { get; set; }

	public virtual DbSet<UserAddress> UserAddresses { get; set; }

	public virtual DbSet<UserRelationship> UserRelationships { get; set; }

	public virtual DbSet<UserSession> UserSessions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Address>(entity =>
		{
			entity.HasKey(e => e.AddressId).HasName("PK__Address__CAA247C81434C0EC");

			entity.ToTable("Address");

			entity.Property(e => e.AddressId).HasColumnName("address_id");
			entity.Property(e => e.City)
				.HasMaxLength(50)
				.HasColumnName("city");
			entity.Property(e => e.Country)
				.HasMaxLength(50)
				.HasColumnName("country");
			entity.Property(e => e.HouseNumber)
				.HasMaxLength(10)
				.HasColumnName("house_number");
			entity.Property(e => e.PostalCode)
				.HasMaxLength(10)
				.HasColumnName("postal_code");
			entity.Property(e => e.State)
				.HasMaxLength(50)
				.HasColumnName("state");
			entity.Property(e => e.Street)
				.HasMaxLength(100)
				.HasColumnName("street");
		});

		modelBuilder.Entity<Bank>(entity =>
		{
			entity.HasKey(e => e.BankId).HasName("PK__Bank__4076F70387093681");

			entity.ToTable("Bank");

			entity.Property(e => e.BankId).HasColumnName("bank_id");
			entity.Property(e => e.ApiEndpoint)
				.HasMaxLength(255)
				.HasColumnName("api_endpoint");
			entity.Property(e => e.ApiVersion)
				.HasMaxLength(20)
				.HasDefaultValue("v1")
				.HasColumnName("api_version");
			entity.Property(e => e.BankName)
				.HasMaxLength(100)
				.HasColumnName("bank_name");
			entity.Property(e => e.ContactEmail)
				.HasMaxLength(100)
				.HasColumnName("contact_email");
			entity.Property(e => e.ContactPhone)
				.HasMaxLength(20)
				.HasColumnName("contact_phone");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
		});

		modelBuilder.Entity<BankAccount>(entity =>
		{
			entity.HasKey(e => e.AccountId).HasName("PK__BankAcco__46A222CD37890FB4");

			entity.ToTable("BankAccount");

			entity.HasIndex(e => e.ApiAccessToken, "UQ__BankAcco__28187BEB28D4E40D").IsUnique();

			entity.HasIndex(e => e.AccountNumber, "UQ__BankAcco__AF91A6AD635085E3").IsUnique();

			entity.Property(e => e.AccountId).HasColumnName("account_id");
			entity.Property(e => e.AccountBalance)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("account_balance");
			entity.Property(e => e.AccountNumber)
				.HasMaxLength(50)
				.HasColumnName("account_number");
			entity.Property(e => e.AccountType)
				.HasMaxLength(50)
				.HasColumnName("account_type");
			entity.Property(e => e.ApiAccessToken)
				.HasMaxLength(255)
				.HasColumnName("api_access_token");
			entity.Property(e => e.BankId).HasColumnName("bank_id");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Currency)
				.HasMaxLength(10)
				.HasDefaultValue("EUR")
				.HasColumnName("currency");
			entity.Property(e => e.Iban)
				.HasMaxLength(34)
				.HasColumnName("iban");
			entity.Property(e => e.LastSyncedAt)
				.HasColumnType("datetime")
				.HasColumnName("last_synced_at");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Bank).WithMany(p => p.BankAccounts)
				.HasForeignKey(d => d.BankId)
				.HasConstraintName("FK__BankAccou__bank___662B2B3B");

			entity.HasOne(d => d.User).WithMany(p => p.BankAccounts)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK__BankAccou__user___65370702");
		});

		modelBuilder.Entity<BankTransaction>(entity =>
		{
			entity.HasKey(e => e.TransactionId).HasName("PK__BankTran__85C600AF22A200E2");

			entity.ToTable("BankTransaction");

			entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
			entity.Property(e => e.AccountId).HasColumnName("account_id");
			entity.Property(e => e.Amount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("amount");
			entity.Property(e => e.BalanceAfter)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("balance_after");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.TransactionDate)
				.HasColumnType("datetime")
				.HasColumnName("transaction_date");
			entity.Property(e => e.TransactionType)
				.HasMaxLength(50)
				.HasColumnName("transaction_type");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasOne(d => d.Account).WithMany(p => p.BankTransactions)
				.HasForeignKey(d => d.AccountId)
				.HasConstraintName("FK__BankTrans__accou__6BE40491");
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B481C94F07");

			entity.ToTable("Category");

			entity.Property(e => e.CategoryId).HasColumnName("category_id");
			entity.Property(e => e.CategoryName)
				.HasMaxLength(100)
				.HasColumnName("category_name");
			entity.Property(e => e.CategoryType)
				.HasMaxLength(50)
				.HasColumnName("category_type");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Description)
				.HasMaxLength(500)
				.HasColumnName("description");
			entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
				.HasForeignKey(d => d.ParentCategoryId)
				.HasConstraintName("FK__Category__parent__4316F928");
		});

		modelBuilder.Entity<Company>(entity =>
		{
			entity.HasKey(e => e.CompanyId).HasName("PK__Company__3E267235E7687D3B");

			entity.ToTable("Company");

			entity.HasIndex(e => e.RegistrationNumber, "UQ__Company__125DB2A3DA5EC4D6").IsUnique();

			entity.HasIndex(e => e.TaxId, "UQ__Company__129B8671141E5918").IsUnique();

			entity.Property(e => e.CompanyId).HasColumnName("company_id");
			entity.Property(e => e.ContactEmail)
				.HasMaxLength(100)
				.HasColumnName("contact_email");
			entity.Property(e => e.ContactPhone)
				.HasMaxLength(20)
				.HasColumnName("contact_phone");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.FoundedDate).HasColumnName("founded_date");
			entity.Property(e => e.Industry)
				.HasMaxLength(50)
				.HasColumnName("industry");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.RegistrationNumber)
				.HasMaxLength(50)
				.HasColumnName("registration_number");
			entity.Property(e => e.TaxId)
				.HasMaxLength(50)
				.HasColumnName("tax_id");
			entity.Property(e => e.Website)
				.HasMaxLength(255)
				.HasColumnName("website");
		});

		modelBuilder.Entity<CompanyAddress>(entity =>
		{
			entity.HasKey(e => e.CompanyAddressId).HasName("PK__CompanyA__5650FC57CC4984E6");

			entity.ToTable("CompanyAddress");

			entity.HasIndex(e => e.AddressType, "UQ__CompanyA__071A9587B0D05465").IsUnique();

			entity.Property(e => e.CompanyAddressId).HasColumnName("company_address_id");
			entity.Property(e => e.AddressId).HasColumnName("address_id");
			entity.Property(e => e.AddressType)
				.HasMaxLength(50)
				.HasColumnName("address_type");
			entity.Property(e => e.CompanyId).HasColumnName("company_id");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.IsDefault)
				.HasDefaultValue(false)
				.HasColumnName("is_default");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasOne(d => d.Address).WithMany(p => p.CompanyAddresses)
				.HasForeignKey(d => d.AddressId)
				.HasConstraintName("FK__CompanyAd__addre__73BA3083");

			entity.HasOne(d => d.Company).WithMany(p => p.CompanyAddresses)
				.HasForeignKey(d => d.CompanyId)
				.HasConstraintName("FK__CompanyAd__compa__72C60C4A");
		});

		modelBuilder.Entity<Debt>(entity =>
		{
			entity.HasKey(e => e.DebtId).HasName("PK__Debt__A7DCE7F913425E57");

			entity.ToTable("Debt");

			entity.Property(e => e.DebtId).HasColumnName("debt_id");
			entity.Property(e => e.AmountOwed)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("amount_owed");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.CreditorCompanyId).HasColumnName("creditor_company_id");
			entity.Property(e => e.CreditorCompanyName)
				.HasMaxLength(100)
				.HasColumnName("creditor_company_name");
			entity.Property(e => e.CreditorFirstName)
				.HasMaxLength(50)
				.HasColumnName("creditor_first_name");
			entity.Property(e => e.CreditorLastName)
				.HasMaxLength(50)
				.HasColumnName("creditor_last_name");
			entity.Property(e => e.CreditorUserId).HasColumnName("creditor_user_id");
			entity.Property(e => e.DebtType)
				.HasMaxLength(50)
				.HasColumnName("debt_type");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.DueDate).HasColumnName("due_date");
			entity.Property(e => e.Frequency)
				.HasMaxLength(50)
				.HasColumnName("frequency");
			entity.Property(e => e.InterestRate)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("interest_rate");
			entity.Property(e => e.NextReminder)
				.HasColumnType("datetime")
				.HasColumnName("next_reminder");
			entity.Property(e => e.Status)
				.HasMaxLength(20)
				.HasDefaultValue("open")
				.HasColumnName("status");
			entity.Property(e => e.TimesRemaining).HasColumnName("times_remaining");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.CreditorCompany).WithMany(p => p.Debts)
				.HasForeignKey(d => d.CreditorCompanyId)
				.HasConstraintName("FK__Debt__creditor_c__4F47C5E3");

			entity.HasOne(d => d.CreditorUser).WithMany(p => p.Debts)
				.HasForeignKey(d => d.CreditorUserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__Debt__creditor_u__4E53A1AA");
		});

		modelBuilder.Entity<Expense>(entity =>
		{
			entity.HasKey(e => e.ExpenseId).HasName("PK__Expense__404B6A6B714931B5");

			entity.ToTable("Expense");

			entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
			entity.Property(e => e.Amount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("amount");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Currency)
				.HasMaxLength(10)
				.HasDefaultValue("EUR")
				.HasColumnName("currency");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.ExpenseCategoryId).HasColumnName("expense_category_id");
			entity.Property(e => e.ExpenseDate).HasColumnName("expense_date");
			entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
			entity.Property(e => e.LastUpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("last_updated_at");
			entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
			entity.Property(e => e.PaymentStatus)
				.HasMaxLength(20)
				.HasDefaultValue("completed")
				.HasColumnName("payment_status");
			entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
			entity.Property(e => e.SourceCompanyId).HasColumnName("source_company_id");
			entity.Property(e => e.SourceCompanyName)
				.HasMaxLength(100)
				.HasColumnName("source_company_name");
			entity.Property(e => e.SourceFirstName)
				.HasMaxLength(50)
				.HasColumnName("source_first_name");
			entity.Property(e => e.SourceLastName)
				.HasMaxLength(50)
				.HasColumnName("source_last_name");
			entity.Property(e => e.SourceType)
				.HasMaxLength(20)
				.HasColumnName("source_type");
			entity.Property(e => e.SourceUserId).HasColumnName("source_user_id");
			entity.Property(e => e.TaxRateId).HasColumnName("tax_rate_id");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.ExpenseCategory).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.ExpenseCategoryId)
				.HasConstraintName("FK__Expense__expense__3587F3E0");

			entity.HasOne(d => d.Frequency).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.FrequencyId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Expense__frequen__395884C4");

			entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.PaymentMethodId)
				.HasConstraintName("FK__Expense__payment__367C1819");

			entity.HasOne(d => d.Receipt).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.ReceiptId)
				.HasConstraintName("FK__Expense__receipt__37703C52");

			entity.HasOne(d => d.SourceCompany).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.SourceCompanyId)
				.HasConstraintName("FK__Expense__source___3493CFA7");

			entity.HasOne(d => d.SourceUser).WithMany(p => p.ExpenseSourceUsers)
				.HasForeignKey(d => d.SourceUserId)
				.HasConstraintName("FK__Expense__source___339FAB6E");

			entity.HasOne(d => d.TaxRate).WithMany(p => p.Expenses)
				.HasForeignKey(d => d.TaxRateId)
				.HasConstraintName("FK__Expense__tax_rat__3864608B");

			entity.HasOne(d => d.User).WithMany(p => p.ExpenseUsers)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Expense__user_id__32AB8735");
		});

		modelBuilder.Entity<ExpenseCategory>(entity =>
		{
			entity.HasKey(e => e.ExpenseCategoryId).HasName("PK__ExpenseC__01F417D73F5C647A");

			entity.ToTable("ExpenseCategory");

			entity.HasIndex(e => e.CategoryName, "UQ__ExpenseC__5189E255EEF6BF80").IsUnique();

			entity.Property(e => e.ExpenseCategoryId).HasColumnName("expense_category_id");
			entity.Property(e => e.Budget)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("budget");
			entity.Property(e => e.CategoryName)
				.HasMaxLength(50)
				.HasColumnName("category_name");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

			entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
				.HasForeignKey(d => d.ParentCategoryId)
				.HasConstraintName("FK__ExpenseCa__paren__2A164134");
		});

		modelBuilder.Entity<Frequency>(entity =>
		{
			entity.HasKey(e => e.FrequencyId).HasName("PK__Frequenc__F32AB2AB880FB888");

			entity.ToTable("Frequency");

			entity.HasIndex(e => e.FrequencyName, "UQ__Frequenc__A9909F222F5DF4F4").IsUnique();

			entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
			entity.Property(e => e.DaysInterval).HasColumnName("days_interval");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.FrequencyName)
				.HasMaxLength(50)
				.HasColumnName("frequency_name");
		});

		modelBuilder.Entity<Income>(entity =>
		{
			entity.HasKey(e => e.IncomeId).HasName("PK__Income__8DC777A62C4377E8");

			entity.ToTable("Income");

			entity.Property(e => e.IncomeId).HasColumnName("income_id");
			entity.Property(e => e.Currency)
				.HasMaxLength(10)
				.HasDefaultValue("EUR")
				.HasColumnName("currency");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
			entity.Property(e => e.GrossAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("gross_amount");
			entity.Property(e => e.IncomeCategoryId).HasColumnName("income_category_id");
			entity.Property(e => e.IncomeDate).HasColumnName("income_date");
			entity.Property(e => e.IsRecurring)
				.HasDefaultValue(false)
				.HasColumnName("is_recurring");
			entity.Property(e => e.LastUpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("last_updated_at");
			entity.Property(e => e.NetAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("net_amount");
			entity.Property(e => e.PayerName)
				.HasMaxLength(100)
				.HasColumnName("payer_name");
			entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
			entity.Property(e => e.ReceivedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("received_at");
			entity.Property(e => e.SourceCompanyId).HasColumnName("source_company_id");
			entity.Property(e => e.SourceName)
				.HasMaxLength(100)
				.HasColumnName("source_name");
			entity.Property(e => e.SourceType)
				.HasMaxLength(20)
				.HasColumnName("source_type");
			entity.Property(e => e.SourceUserId).HasColumnName("source_user_id");
			entity.Property(e => e.TaxAmount)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("tax_amount");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Frequency).WithMany(p => p.Incomes)
				.HasForeignKey(d => d.FrequencyId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Income__frequenc__25518C17");

			entity.HasOne(d => d.IncomeCategory).WithMany(p => p.Incomes)
				.HasForeignKey(d => d.IncomeCategoryId)
				.HasConstraintName("FK__Income__income_c__2180FB33");

			entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Incomes)
				.HasForeignKey(d => d.PaymentMethodId)
				.HasConstraintName("FK__Income__payment___245D67DE");

			entity.HasOne(d => d.SourceCompany).WithMany(p => p.Incomes)
				.HasForeignKey(d => d.SourceCompanyId)
				.HasConstraintName("FK__Income__source_c__236943A5");

			entity.HasOne(d => d.SourceUser).WithMany(p => p.IncomeSourceUsers)
				.HasForeignKey(d => d.SourceUserId)
				.HasConstraintName("FK__Income__source_u__22751F6C");

			entity.HasOne(d => d.User).WithMany(p => p.IncomeUsers)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Income__user_id__208CD6FA");
		});

		modelBuilder.Entity<IncomeCategory>(entity =>
		{
			entity.HasKey(e => e.IncomeCategoryId).HasName("PK__IncomeCa__95C31FD04B6F8760");

			entity.ToTable("IncomeCategory");

			entity.HasIndex(e => e.CategoryName, "UQ__IncomeCa__5189E2550F873F42").IsUnique();

			entity.Property(e => e.IncomeCategoryId).HasColumnName("income_category_id");
			entity.Property(e => e.CategoryName)
				.HasMaxLength(50)
				.HasColumnName("category_name");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

			entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
				.HasForeignKey(d => d.ParentCategoryId)
				.HasConstraintName("FK__IncomeCat__paren__17F790F9");
		});

		modelBuilder.Entity<Investment>(entity =>
		{
			entity.HasKey(e => e.InvestmentId).HasName("PK__Investme__2093C283C4A88188");

			entity.Property(e => e.InvestmentId).HasColumnName("investment_id");
			entity.Property(e => e.Amount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("amount");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.InterestRate)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("interest_rate");
			entity.Property(e => e.InvestmentDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnName("investment_date");
			entity.Property(e => e.InvestmentType)
				.HasMaxLength(50)
				.HasColumnName("investment_type");
			entity.Property(e => e.LoanedToCompanyId).HasColumnName("loaned_to_company_id");
			entity.Property(e => e.LoanedToFirstName)
				.HasMaxLength(50)
				.HasColumnName("loaned_to_first_name");
			entity.Property(e => e.LoanedToLastName)
				.HasMaxLength(50)
				.HasColumnName("loaned_to_last_name");
			entity.Property(e => e.LoanedToUserId).HasColumnName("loaned_to_user_id");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.LoanedToCompany).WithMany(p => p.Investments)
				.HasForeignKey(d => d.LoanedToCompanyId)
				.HasConstraintName("FK__Investmen__loane__56E8E7AB");

			entity.HasOne(d => d.LoanedToUser).WithMany(p => p.Investments)
				.HasForeignKey(d => d.LoanedToUserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__Investmen__loane__55F4C372");
		});

		modelBuilder.Entity<Label>(entity =>
		{
			entity.HasKey(e => e.LabelId).HasName("PK__Label__E44FFA5872065241");

			entity.ToTable("Label");

			entity.HasIndex(e => e.LabelName, "UQ__Label__A74BEA651F478188").IsUnique();

			entity.Property(e => e.LabelId).HasColumnName("label_id");
			entity.Property(e => e.ColorCode)
				.HasMaxLength(7)
				.HasColumnName("color_code");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.LabelName)
				.HasMaxLength(50)
				.HasColumnName("label_name");
		});

		modelBuilder.Entity<LabelAssignment>(entity =>
		{
			entity.HasKey(e => e.LabelAssignmentId).HasName("PK__LabelAss__F27DEC24E3563F24");

			entity.ToTable("LabelAssignment");

			entity.Property(e => e.LabelAssignmentId).HasColumnName("label_assignment_id");
			entity.Property(e => e.AssignedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("assigned_at");
			entity.Property(e => e.EntityId).HasColumnName("entity_id");
			entity.Property(e => e.EntityType)
				.HasMaxLength(50)
				.HasColumnName("entity_type");
			entity.Property(e => e.LabelId).HasColumnName("label_id");

			entity.HasOne(d => d.Label).WithMany(p => p.LabelAssignments)
				.HasForeignKey(d => d.LabelId)
				.HasConstraintName("FK__LabelAssi__label__49C3F6B7");
		});

		modelBuilder.Entity<PaymentMethod>(entity =>
		{
			entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__8A3EA9EB9B8919FC");

			entity.ToTable("PaymentMethod");

			entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
			entity.Property(e => e.Abbreviation)
				.HasMaxLength(10)
				.HasColumnName("abbreviation");
			entity.Property(e => e.Description)
				.HasMaxLength(255)
				.HasColumnName("description");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF51756F8BB");

			entity.ToTable("Product");

			entity.Property(e => e.ProductId).HasColumnName("product_id");
			entity.Property(e => e.Brand)
				.HasMaxLength(50)
				.HasColumnName("brand");
			entity.Property(e => e.CategoryId).HasColumnName("category_id");
			entity.Property(e => e.Code)
				.HasMaxLength(50)
				.HasColumnName("code");
			entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
			entity.Property(e => e.FullName)
				.HasMaxLength(255)
				.HasColumnName("full_name");
			entity.Property(e => e.InlineTotalPrice)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("inline_total_price");
			entity.Property(e => e.InlineTotalVolume)
				.HasColumnType("decimal(10, 3)")
				.HasColumnName("inline_total_volume");
			entity.Property(e => e.InlineTotalWeight)
				.HasColumnType("decimal(10, 3)")
				.HasColumnName("inline_total_weight");
			entity.Property(e => e.IppUnit).HasColumnName("ipp_unit");
			entity.Property(e => e.IsBio).HasColumnName("is_bio");
			entity.Property(e => e.ItemsPerPackage).HasColumnName("items_per_package");
			entity.Property(e => e.OriginCountry)
				.HasMaxLength(50)
				.HasColumnName("origin_country");
			entity.Property(e => e.QUnit).HasColumnName("q_unit");
			entity.Property(e => e.Quantity).HasColumnName("quantity");
			entity.Property(e => e.ShortName)
				.HasMaxLength(100)
				.HasColumnName("short_name");
			entity.Property(e => e.StoreDescription)
				.HasMaxLength(500)
				.HasColumnName("store_description");
			entity.Property(e => e.TaxCode)
				.HasMaxLength(3)
				.IsUnicode(false)
				.IsFixedLength()
				.HasColumnName("tax_code");
			entity.Property(e => e.UnitPrice)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("unit_price");
			entity.Property(e => e.UpUnit).HasColumnName("up_unit");
			entity.Property(e => e.UserDescription)
				.HasMaxLength(500)
				.HasColumnName("user_description");
			entity.Property(e => e.VUnit).HasColumnName("v_unit");
			entity.Property(e => e.VatRate)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("vat_rate");
			entity.Property(e => e.VolumePerUnit)
				.HasColumnType("decimal(10, 3)")
				.HasColumnName("volume_per_unit");
			entity.Property(e => e.WUnit).HasColumnName("w_unit");
			entity.Property(e => e.WeightPerUnit)
				.HasColumnType("decimal(10, 3)")
				.HasColumnName("weight_per_unit");

			entity.HasOne(d => d.IppUnitNavigation).WithMany(p => p.ProductIppUnitNavigations)
				.HasForeignKey(d => d.IppUnit)
				.HasConstraintName("FK__Product__ipp_uni__02084FDA");

			entity.HasOne(d => d.QUnitNavigation).WithMany(p => p.ProductQUnitNavigations)
				.HasForeignKey(d => d.QUnit)
				.HasConstraintName("FK__Product__q_unit__01142BA1");

			entity.HasOne(d => d.UpUnitNavigation).WithMany(p => p.ProductUpUnitNavigations)
				.HasForeignKey(d => d.UpUnit)
				.HasConstraintName("FK__Product__up_unit__04E4BC85");

			entity.HasOne(d => d.VUnitNavigation).WithMany(p => p.ProductVUnitNavigations)
				.HasForeignKey(d => d.VUnit)
				.HasConstraintName("FK__Product__v_unit__03F0984C");

			entity.HasOne(d => d.WUnitNavigation).WithMany(p => p.ProductWUnitNavigations)
				.HasForeignKey(d => d.WUnit)
				.HasConstraintName("FK__Product__w_unit__02FC7413");
		});

		modelBuilder.Entity<Receipt>(entity =>
		{
			entity.HasKey(e => e.ReceiptId).HasName("PK__Receipt__91F52C1FA2C53D87");

			entity.ToTable("Receipt");

			entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
			entity.Property(e => e.BuyDatetime)
				.HasColumnType("datetime")
				.HasColumnName("buy_datetime");
			entity.Property(e => e.CashbackAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("cashback_amount");
			entity.Property(e => e.Currency)
				.HasMaxLength(10)
				.HasColumnName("currency");
			entity.Property(e => e.FullNamePaymentMethod)
				.HasMaxLength(255)
				.HasColumnName("full_name_payment_method");
			entity.Property(e => e.Iban)
				.HasMaxLength(34)
				.IsUnicode(false)
				.IsFixedLength()
				.HasColumnName("iban");
			entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
			entity.Property(e => e.ReceiptImagePath)
				.HasMaxLength(255)
				.HasColumnName("receipt_image_path");
			entity.Property(e => e.StoreId).HasColumnName("store_id");
			entity.Property(e => e.TotalAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("total_amount");
			entity.Property(e => e.TotalLoyalty)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("total_loyalty");
			entity.Property(e => e.TraceNumber)
				.HasMaxLength(50)
				.HasColumnName("trace_number");

			entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Receipts)
				.HasForeignKey(d => d.PaymentMethodId)
				.HasConstraintName("FK__Receipt__payment__08B54D69");

			entity.HasOne(d => d.Store).WithMany(p => p.Receipts)
				.HasForeignKey(d => d.StoreId)
				.HasConstraintName("FK__Receipt__store_i__09A971A2");
		});

		modelBuilder.Entity<ReceiptPayment>(entity =>
		{
			entity.HasKey(e => e.ReceiptPaymentId).HasName("PK__ReceiptP__CE878B50AB921B4A");

			entity.ToTable("ReceiptPayment");

			entity.Property(e => e.ReceiptPaymentId).HasColumnName("receipt_payment_id");
			entity.Property(e => e.Amount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("amount");
			entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
			entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

			entity.HasOne(d => d.PaymentMethod).WithMany(p => p.ReceiptPayments)
				.HasForeignKey(d => d.PaymentMethodId)
				.HasConstraintName("FK__ReceiptPa__payme__14270015");

			entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptPayments)
				.HasForeignKey(d => d.ReceiptId)
				.HasConstraintName("FK__ReceiptPa__recei__1332DBDC");
		});

		modelBuilder.Entity<ReceiptTaxDetail>(entity =>
		{
			entity.HasKey(e => e.ReceiptTaxDetailId).HasName("PK__ReceiptT__190DF74F5F3FD40C");

			entity.ToTable("ReceiptTaxDetail");

			entity.Property(e => e.ReceiptTaxDetailId).HasColumnName("receipt_tax_detail_id");
			entity.Property(e => e.NetSalesAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("net_sales_amount");
			entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
			entity.Property(e => e.TaxRateId).HasColumnName("tax_rate_id");
			entity.Property(e => e.VatAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("vat_amount");

			entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptTaxDetails)
				.HasForeignKey(d => d.ReceiptId)
				.HasConstraintName("FK__ReceiptTa__recei__0F624AF8");

			entity.HasOne(d => d.TaxRate).WithMany(p => p.ReceiptTaxDetails)
				.HasForeignKey(d => d.TaxRateId)
				.HasConstraintName("FK__ReceiptTa__tax_r__10566F31");
		});

		modelBuilder.Entity<Saving>(entity =>
		{
			entity.HasKey(e => e.SavingsId).HasName("PK__Savings__AC1BA043D0E18128");

			entity.Property(e => e.SavingsId).HasColumnName("savings_id");
			entity.Property(e => e.AccumulatedInterest)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("accumulated_interest");
			entity.Property(e => e.ContributionAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("contribution_amount");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
			entity.Property(e => e.InterestRate)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("interest_rate");
			entity.Property(e => e.LastUpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("last_updated_at");
			entity.Property(e => e.Notes)
				.HasMaxLength(500)
				.HasColumnName("notes");
			entity.Property(e => e.SavedAmount)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("saved_amount");
			entity.Property(e => e.SavingsGoal)
				.HasMaxLength(255)
				.HasColumnName("savings_goal");
			entity.Property(e => e.StartDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnName("start_date");
			entity.Property(e => e.Status)
				.HasMaxLength(20)
				.HasDefaultValue("in-progress")
				.HasColumnName("status");
			entity.Property(e => e.TargetAmount)
				.HasColumnType("decimal(18, 2)")
				.HasColumnName("target_amount");
			entity.Property(e => e.TargetDate).HasColumnName("target_date");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Frequency).WithMany(p => p.Savings)
				.HasForeignKey(d => d.FrequencyId)
				.HasConstraintName("FK__Savings__frequen__44CA3770");

			entity.HasOne(d => d.User).WithMany(p => p.Savings)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK__Savings__user_id__43D61337");
		});

		modelBuilder.Entity<Store>(entity =>
		{
			entity.HasKey(e => e.StoreId).HasName("PK__Store__A2F2A30C9852CCAC");

			entity.ToTable("Store");

			entity.Property(e => e.StoreId).HasColumnName("store_id");
			entity.Property(e => e.AddressId).HasColumnName("address_id");
			entity.Property(e => e.BrandName)
				.HasMaxLength(100)
				.HasColumnName("brand_name");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.TaxId)
				.HasMaxLength(20)
				.HasColumnName("tax_id");

			entity.HasOne(d => d.Address).WithMany(p => p.Stores)
				.HasForeignKey(d => d.AddressId)
				.HasConstraintName("FK__Store__address_i__76969D2E");
		});

		modelBuilder.Entity<StoreAddress>(entity =>
		{
			entity.HasKey(e => e.CompanyAddressId).HasName("PK__StoreAdd__5650FC573D98C8C0");

			entity.ToTable("StoreAddress");

			entity.HasIndex(e => e.AddressType, "UQ__StoreAdd__071A9587EC1B4587").IsUnique();

			entity.Property(e => e.CompanyAddressId).HasColumnName("company_address_id");
			entity.Property(e => e.AddressId).HasColumnName("address_id");
			entity.Property(e => e.AddressType)
				.HasMaxLength(50)
				.HasColumnName("address_type");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.IsDefault)
				.HasDefaultValue(false)
				.HasColumnName("is_default");
			entity.Property(e => e.StoreId).HasColumnName("store_id");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasOne(d => d.Address).WithMany(p => p.StoreAddresses)
				.HasForeignKey(d => d.AddressId)
				.HasConstraintName("FK__StoreAddr__addre__7E37BEF6");

			entity.HasOne(d => d.Store).WithMany(p => p.StoreAddresses)
				.HasForeignKey(d => d.StoreId)
				.HasConstraintName("FK__StoreAddr__store__7D439ABD");
		});

		modelBuilder.Entity<TaxRate>(entity =>
		{
			entity.HasKey(e => e.TaxRateId).HasName("PK__TaxRate__4B78B3339E326A41");

			entity.ToTable("TaxRate");

			entity.Property(e => e.TaxRateId).HasColumnName("tax_rate_id");
			entity.Property(e => e.NetAmount)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("net_amount");
			entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
			entity.Property(e => e.TaxCode)
				.HasMaxLength(3)
				.IsUnicode(false)
				.IsFixedLength()
				.HasColumnName("tax_code");
			entity.Property(e => e.VatAmount)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("vat_amount");
			entity.Property(e => e.VatRate)
				.HasColumnType("decimal(5, 2)")
				.HasColumnName("vat_rate");

			entity.HasOne(d => d.Receipt).WithMany(p => p.TaxRates)
				.HasForeignKey(d => d.ReceiptId)
				.HasConstraintName("FK__TaxRate__receipt__0C85DE4D");
		});

		modelBuilder.Entity<UnitType>(entity =>
		{
			entity.HasKey(e => e.UnitId).HasName("PK__UnitType__D3AF5BD72F731E9A");

			entity.ToTable("UnitType");

			entity.Property(e => e.UnitId).HasColumnName("unit_id");
			entity.Property(e => e.UnitName)
				.HasMaxLength(50)
				.HasColumnName("unit_name");
			entity.Property(e => e.UnitType1)
				.HasMaxLength(50)
				.HasColumnName("unit_type");
		});

		modelBuilder.Entity<UserAddress>(entity =>
		{
			entity.HasKey(e => e.CompanyAddressId).HasName("PK__UserAddr__5650FC5748220D98");

			entity.ToTable("UserAddress");

			entity.HasIndex(e => e.AddressType, "UQ__UserAddr__071A95874A01A788").IsUnique();

			entity.Property(e => e.CompanyAddressId).HasColumnName("company_address_id");
			entity.Property(e => e.AddressId).HasColumnName("address_id");
			entity.Property(e => e.AddressType)
				.HasMaxLength(50)
				.HasColumnName("address_type");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.IsDefault)
				.HasDefaultValue(false)
				.HasColumnName("is_default");
			entity.Property(e => e.UpdatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Address).WithMany(p => p.UserAddresses)
				.HasForeignKey(d => d.AddressId)
				.HasConstraintName("FK__UserAddre__addre__5AEE82B9");

			entity.HasOne(d => d.User).WithMany(p => p.UserAddresses)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK__UserAddre__user___59FA5E80");
		});

		modelBuilder.Entity<UserRelationship>(entity =>
		{
			entity.HasKey(e => e.RelationshipId).HasName("PK__UserRela__C0CFD554024C1505");

			entity.ToTable("UserRelationship");

			entity.Property(e => e.RelationshipId).HasColumnName("relationship_id");
			entity.Property(e => e.CreatedAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.RelatedUserId).HasColumnName("related_user_id");
			entity.Property(e => e.RelationshipType)
				.HasMaxLength(50)
				.HasColumnName("relationship_type");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.RelatedUser).WithMany(p => p.UserRelationshipRelatedUsers)
				.HasForeignKey(d => d.RelatedUserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__UserRelat__relat__60A75C0F");

			entity.HasOne(d => d.User).WithMany(p => p.UserRelationshipUsers)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__UserRelat__user___5FB337D6");
		});

		modelBuilder.Entity<UserSession>(entity =>
		{
			entity.HasKey(e => e.SessionId).HasName("PK__UserSess__69B13FDCEE3067BE");

			entity.ToTable("UserSession");

			entity.HasIndex(e => e.SessionToken, "UQ__UserSess__E598F5C8FA9398C8").IsUnique();

			entity.Property(e => e.SessionId).HasColumnName("session_id");
			entity.Property(e => e.Browser)
				.HasMaxLength(50)
				.HasColumnName("browser");
			entity.Property(e => e.Device)
				.HasMaxLength(100)
				.HasColumnName("device");
			entity.Property(e => e.FailedLoginAttempts)
				.HasDefaultValue(0)
				.HasColumnName("failed_login_attempts");
			entity.Property(e => e.IpAddress)
				.HasMaxLength(45)
				.HasColumnName("ip_address");
			entity.Property(e => e.IsActive)
				.HasDefaultValue(true)
				.HasColumnName("is_active");
			entity.Property(e => e.Location)
				.HasMaxLength(100)
				.HasColumnName("location");
			entity.Property(e => e.LoginAttempts)
				.HasDefaultValue(1)
				.HasColumnName("login_attempts");
			entity.Property(e => e.LoginTime)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("login_time");
			entity.Property(e => e.LogoutTime)
				.HasColumnType("datetime")
				.HasColumnName("logout_time");
			entity.Property(e => e.OperatingSystem)
				.HasMaxLength(50)
				.HasColumnName("operating_system");
			entity.Property(e => e.SessionDuration)
				.HasComputedColumnSql("(datediff(minute,[login_time],[logout_time]))", false)
				.HasColumnName("session_duration");
			entity.Property(e => e.SessionToken)
				.HasMaxLength(255)
				.HasColumnName("session_token");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.User).WithMany(p => p.UserSessions)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__UserSessi__user___68487DD7");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
