using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapPost("/v2/categories", async (CreateCategoryRequest request, ICategoryHandler handler) =>
     await handler.CreateAsync(request))
        .WithName("Categories: Create")
        .WithSummary("Cria uma nova categoria")
        .Produces<Response<Category>>();

app.MapPut("/v2/categories/{id}", async ([FromRoute]long id, [FromBody]UpdateCategoryRequest request, [FromServices]ICategoryHandler handler) => 
{
    request.Id = id;
    await handler.UpdateAsync(request);

})
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<Response<Category>>();


app.MapDelete("/v2/categories/{id}", async ([FromRoute] long id, [FromBody] DeleteCategoryRequest request, [FromServices]ICategoryHandler handler) =>
{
    request.Id = id;
    await handler.DeleteAsync(request);
})
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<Response<Category>>();

app.Run();  
