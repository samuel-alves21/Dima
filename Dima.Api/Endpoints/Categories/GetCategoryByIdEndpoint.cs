using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;
public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
        .WithName("Categories: GetById")
        .WithSummary("Busca uma categoria pelo id")
        .WithDescription("Busca uma categoria pelo id")
        .WithOrder(4)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(long id, [FromServices] CategoryHandler handler)
    {
        var request = new GetCategoryByIdRequest()
        {
            Id = id,
            UserId = "samuel@samuel"
        };

        var result = await handler.GetByIdAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}
