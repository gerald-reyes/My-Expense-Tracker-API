using System;
using System.Collections.Generic;

namespace ExpenseTracker.Infrastructure.Data.Models;

public partial class ExpenseSubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ParentCategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsRecurring { get; set; }

    public virtual ExpenseCategory ParentCategory { get; set; } = null!;
}
