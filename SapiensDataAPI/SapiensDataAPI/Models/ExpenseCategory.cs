using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class ExpenseCategory
{
    public int ExpenseCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Budget { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<ExpenseCategory> InverseParentCategory { get; set; } = new List<ExpenseCategory>();

    public virtual ExpenseCategory? ParentCategory { get; set; }
}
