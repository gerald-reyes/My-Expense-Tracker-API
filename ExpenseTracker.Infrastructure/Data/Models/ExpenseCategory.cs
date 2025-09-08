using System;
using System.Collections.Generic;
using HotChocolate;

namespace ExpenseTracker.Infrastructure.Data.Models;

public partial class ExpenseCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }
    public int? ParentId { get; set; }

    public ExpenseCategory? Parent { get; set; }

    public ICollection<ExpenseCategory> Children { get; set; } = new List<ExpenseCategory>();
}
