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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<ExpenseCategoryQuery>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<ExpenseCategoryMutation>();

var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
