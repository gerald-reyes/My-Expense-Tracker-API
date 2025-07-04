﻿using System;
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

    [GraphQLIgnore]
    public virtual ICollection<ExpenseSubCategory> ExpenseSubCategories { get; set; } = new List<ExpenseSubCategory>();
}
