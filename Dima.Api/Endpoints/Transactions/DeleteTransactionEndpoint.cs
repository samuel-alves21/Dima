using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
    .WithName("Transactions: Delete")
    .WithSummary("Exclui uma transação")
    .WithDescription("Exclui uma transação")
    .WithOrder(3)
    .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(long id, [FromServices] TransactionHandler handler)
    {
        var request = new DeleteTransactionRequest()
        {
            Id = id,
            UserId = "samuel@samuel"
        };

        var result = await handler.DeleteAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}

