using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id}", HandleAsync)
        .WithName("Categories: Update")
        .WithSummary("Atualiza uma categoria")
        .WithDescription("Atualiza uma categoria")
        .WithOrder(2)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(UpdateCategoryRequest request, long id, [FromServices] CategoryHandler handler)
    {
        request.Id = id;
        request.UserId = "samuel@samuel";

        var result = await handler.UpdateAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}
