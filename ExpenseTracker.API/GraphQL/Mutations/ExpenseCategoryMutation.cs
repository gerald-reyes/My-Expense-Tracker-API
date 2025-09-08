using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;
using HotChocolate; // for GraphQL attributes
using HotChocolate.Types; // for ExtendObjectType

namespace ExpenseTracker.API.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ExpenseCategoryMutation
{
    public async Task<ExpenseCategory> CreateExpenseCategory(
        CreateExpenseCategoryInput input,
        [Service] AppDbContext context)
    {
        Console.WriteLine(
            $"Debug: Creating ExpenseCategory with input: Name={input.Name}, Description={input.Description}");

        var expenseCategory = new ExpenseCategory
        {
            Name = input.Name,
            Description = input.Description,
            IsActive = input.IsActive ?? false
        };

        context.ExpenseCategories.Add(expenseCategory);
        await context.SaveChangesAsync();
        return expenseCategory;
    }

    [GraphQLName("CreateExpenseCategoryInput")]
    public class CreateExpenseCategoryInput
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }

    [GraphQLName("UpdateExpenseCategoryInput")]
    public class UpdateExpenseCategoryInput
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }

    public async Task<ExpenseCategory> UpdateExpenseCategory(
        UpdateExpenseCategoryInput input,
        [Service] AppDbContext context)
    {
        var expenseCategory = await context.ExpenseCategories.FindAsync(input.Id);
        if (expenseCategory == null) throw new Exception("ExpenseCategory not found");

        expenseCategory.Name = input.Name;
        expenseCategory.Description = input.Description;
        expenseCategory.IsActive = input.IsActive;

        await context.SaveChangesAsync();
        return expenseCategory;
    }

    public async Task<bool> DeleteExpenseCategory(int id, [Service] AppDbContext context)
    {
        var expenseCategory = await context.ExpenseCategories.FindAsync(id);
        if (expenseCategory == null) throw new Exception("ExpenseCategory not found");

        context.ExpenseCategories.Remove(expenseCategory);
        await context.SaveChangesAsync();
        return true;
    }
}
