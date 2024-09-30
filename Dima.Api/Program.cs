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
        .Produces<Response<Category?>>();

app.MapPut("/v2/categories/{id}", async ([FromRoute]long id, [FromBody] UpdateCategoryRequest request, [FromServices] ICategoryHandler handler) => 
{
    request.Id = id;
    return await handler.UpdateAsync(request);

})
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<Response<Category?>>();


app.MapDelete("/v2/categories/{id}", async ([FromRoute] long id, [FromServices] ICategoryHandler handler) =>
{
    var request = new DeleteCategoryRequest()
    {
        Id = id,
        UserId = "samuel@samuel"
    };

    return await handler.DeleteAsync(request);
})
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<Response<Category?>>();

app.MapGet("/v2/categories/{id}", async ([FromRoute] long id, [FromServices] ICategoryHandler handler) =>
{
    var request = new GetCategoryByIdRequest()
    {
        Id = id,
        UserId = "samuel@samuel"
    };

    return await handler.GetByIdAsync(request);
})
    .WithName("Categories: GetById")
    .WithSummary("Retorna uma categoria pelo Id")
    .Produces<Response<Category?>>();

app.MapGet("/v2/categories/", async ([FromServices] ICategoryHandler handler) =>
{
    var request = new GetAllCategoriesRequest()
    {
        UserId = "samuel@samuel"
    };

    return await handler.GetAllAsync(request);
})
    .WithName("Categories: GetAll")
    .WithSummary("Retorna todas as categorias")
    .Produces<PagedResponse<List<Category>?>>();

app.Run();  
