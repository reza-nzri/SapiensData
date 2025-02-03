using System;
using System.Collections.Generic;

namespace SapiensDataAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentCategoryId { get; set; }

    public string? CategoryType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }
}
