using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Frequency
{
    public int FrequencyId { get; set; }

    public string FrequencyName { get; set; } = null!;

    public string? Description { get; set; }

    public int? DaysInterval { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();

    public virtual ICollection<Saving> Savings { get; set; } = new List<Saving>();
}
