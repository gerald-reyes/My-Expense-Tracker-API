using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;

namespace ExpenseTracker.API.GraphQL.Mutations;

[ExtendObjectType(Name = "Mutation")]
public class ExpenseCategoryMutation
{
    public async Task<ExpenseCategory> CreateExpenseCategory(CreateExpenseCategoryInput input, [Service] AppDbContext context)
    {
        Console.WriteLine($"Debug: Creating ExpenseCategory with input: Name={input.name}, Description={input.description}");
        var expenseCategory = new ExpenseCategory
        {
            Name = input.name,
            Description = input.description,
            IsActive = input.isActive ?? false
        };
        context.ExpenseCategories.Add(expenseCategory);
        await context.SaveChangesAsync();
        return expenseCategory;
    }

    public class CreateExpenseCategoryInput
    {
        public string name { get; set; }
        public string? description { get; set; }
        public bool? isActive { get; set; }
    }

    public class UpdateExpenseCategoryInput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
    }

    public async Task<ExpenseCategory> UpdateExpenseCategory(UpdateExpenseCategoryInput input, [Service] AppDbContext context)
    {
        var expenseCategory = await context.ExpenseCategories.FindAsync(input.id);
        if (expenseCategory == null) throw new Exception("ExpenseCategory not found");

        expenseCategory.Name = input.name;
        expenseCategory.Description = input.description;
        expenseCategory.IsActive = input.isActive;

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
