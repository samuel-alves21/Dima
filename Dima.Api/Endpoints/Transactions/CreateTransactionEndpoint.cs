using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync)
        .WithName("Transactions: Create")
        .WithSummary("Cria uma nova transação")
        .WithDescription("Cria uma nova transação")
        .WithOrder(1)
        .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(CreateTransactionRequest request, [FromServices] TransactionHandler handler)
    {
        var result = await handler.CreateAsync(request);

        if (result.IsSuccess) return TypedResults.Created($"/{result.Data?.Id}", result);

        return TypedResults.BadRequest(result); 
    }
}


