using Xunit;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.API.GraphQL.Queries;
using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests;

public class ExpenseCategoryQueryTests
{
    [Fact]
    public async Task GetExpenseCategories_ReturnsAll()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        await using var context = new AppDbContext(options);
        context.ExpenseCategories.AddRange(
            new ExpenseCategory { Name = "Utilities", IsActive = true },
            new ExpenseCategory { Name = "Food", IsActive = true }
        );
        await context.SaveChangesAsync();

        var query = new ExpenseCategoryQuery();
        var result = await query.GetExpenseCategories(context);

        Assert.NotNull(result);
        Assert.Equal(2, new List<ExpenseCategory>(result).Count);
    }
}
