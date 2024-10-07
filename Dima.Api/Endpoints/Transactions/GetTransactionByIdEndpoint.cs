using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
         .WithName("Transactions: GetById")
         .WithSummary("Busca uma transação pelo id")
         .WithDescription("Busca uma transação pelo id")
         .WithOrder(4)
         .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(long id, [FromServices] TransactionHandler handler)
    {
        var request = new GetTransactionByIdRequest()
        {
            Id = id,
            UserId = "samuel@samuel"
        };

        var result = await handler.GetByIdAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}

