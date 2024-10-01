using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;

namespace Dima.Core.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync)
        .WithName("Categories: Create")
        .WithSummary("Cria uma nova categoria")
        .WithDescription("Cria uma nova categoria")
        .WithOrder(1);
        
    private static async Task<IResult> HandleAsync(CategoryHandler handler, CreateCategoryRequest request)
    {
        var result = await handler.CreateAsync(request);

        if (result.IsSuccess) return TypedResults.Created($"/{result.Data?.Id}", result.Data);

        return TypedResults.BadRequest(result.Data);
    }
}