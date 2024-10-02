using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
        .WithName("Categories: Delete")
        .WithSummary("Exclui uma categoria")
        .WithDescription("Exclui uma categoria")
        .WithOrder(3)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(long id, [FromServices] CategoryHandler handler)
    {
        var request = new DeleteCategoryRequest()
        {
            Id = id,
            UserId = "samuel@samuel"
        };

        var result = await handler.DeleteAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}

