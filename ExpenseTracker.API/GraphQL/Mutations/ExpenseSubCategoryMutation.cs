using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;

namespace ExpenseTracker.API.GraphQL.Mutations;

public class ExpenseSubCategoryMutation
{
    public async Task<ExpenseSubCategory> CreateExpenseSubCategory(ExpenseSubCategory input, [Service] AppDbContext context)
    {
        context.ExpenseSubCategories.Add(input);
        await context.SaveChangesAsync();
        return input;
    }
}
