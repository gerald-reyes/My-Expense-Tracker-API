using ExpenseTracker.API.GraphQL.Mutations;
using ExpenseTracker.API.GraphQL.Queries;
using ExpenseTracker.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Read from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddType<ExpenseCategoryQuery>()
        .AddType<ExpenseSubCategoryQuery>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddType<ExpenseCategoryMutation>()
        .AddType<ExpenseSubCategoryMutation>();

var app = builder.Build();

app.MapGraphQL();
app.Run();
