using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync)
    .WithName("Categories: GetAll")
    .WithSummary("Busca todas as categorias")
    .WithDescription("Busca todas as categorias")
    .WithOrder(5)
    .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync([FromServices] CategoryHandler handler, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest()
        {
            UserId = "samuel@samuel",
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}

