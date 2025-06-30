using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;

namespace ExpenseTracker.API.GraphQL.Mutations;

public class ExpenseCategoryMutation
{
    public async Task<ExpenseCategory> CreateExpenseCategory(ExpenseCategory input, [Service] AppDbContext context)
    {
        context.ExpenseCategories.Add(input);
        await context.SaveChangesAsync();
        return input;
    }
}
