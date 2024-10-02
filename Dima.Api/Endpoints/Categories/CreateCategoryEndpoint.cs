using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync)
        .WithName("Categories: Create")
        .WithSummary("Cria uma nova categoria")
        .WithDescription("Cria uma nova categoria")
        .WithOrder(1)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(CreateCategoryRequest request, [FromServices] CategoryHandler handler)
    {
        var result = await handler.CreateAsync(request);

        if (result.IsSuccess) return TypedResults.Created($"/{result.Data?.Id}", result);

        return TypedResults.BadRequest(result);
    }
}