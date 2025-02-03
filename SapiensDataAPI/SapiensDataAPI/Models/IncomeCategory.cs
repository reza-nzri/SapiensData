using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class IncomeCategory
{
    public int IncomeCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();

    public virtual ICollection<IncomeCategory> InverseParentCategory { get; set; } = new List<IncomeCategory>();

    public virtual IncomeCategory? ParentCategory { get; set; }
}
