using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.GraphQL.Queries;

public class ExpenseCategoryQuery
{
    public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategories([Service] AppDbContext context)
        => await context.ExpenseCategories.ToListAsync();

    public async Task<ExpenseCategory?> GetExpenseCategory(int id, [Service] AppDbContext context)
        => await context.ExpenseCategories.FindAsync(id);
}
