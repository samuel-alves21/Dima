using Dima.Api.Data;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((x) =>
{
    x.CustomSchemaIds((n) => n.FullName);
});

builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapPost("/v2/categories", (CreateCategoryRequest request, Handler handler) =>
{
    return handler.Handle(request);
})  
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category>>();

app.Run();
