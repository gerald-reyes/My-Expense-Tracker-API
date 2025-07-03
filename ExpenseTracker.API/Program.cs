using ExpenseTracker.API.GraphQL.Mutations;
using ExpenseTracker.API.GraphQL.Queries;
using ExpenseTracker.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// Read from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddGraphQLServer()
    .AddQueryType<ExpenseCategoryQuery>()
    .AddTypeExtension<ExpenseSubCategoryQuery>()
    .AddMutationType<ExpenseCategoryMutation>()
    .AddTypeExtension<ExpenseSubCategoryMutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
