using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.GraphQL.Queries;

public class ExpenseSubCategoryQuery
{
    public async Task<IEnumerable<ExpenseSubCategory>> GetExpenseSubCategories([Service] AppDbContext context)
        => await context.ExpenseSubCategories.ToListAsync();

    public async Task<IEnumerable<ExpenseSubCategory>> GetByParent(int parentCategoryId, [Service] AppDbContext context)
        => await context.ExpenseSubCategories
            .Where(x => x.ParentCategoryId == parentCategoryId)
            .ToListAsync();
}
