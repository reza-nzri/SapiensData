using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Industry { get; set; }

    public string? Description { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? TaxId { get; set; }

    public string? Website { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateOnly? FoundedDate { get; set; }

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();

    public virtual ICollection<Investment> Investments { get; set; } = new List<Investment>();
}
