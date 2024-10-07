using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id}", HandleAsync)
    .WithName("Transactions: Update")
    .WithSummary("Atualiza uma transação")
    .WithDescription("Atualiza uma transação")
    .WithOrder(2)
    .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(UpdateTransactionRequest request, long id, [FromServices] TransactionHandler handler)
    {
        request.Id = id;
        request.UserId = "samuel@samuel";

        var result = await handler.UpdateAsync(request);

        if (result.IsSuccess) return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}

