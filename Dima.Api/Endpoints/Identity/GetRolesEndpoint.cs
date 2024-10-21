using Dima.Api.Common.Api;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Endpoints.Identity;
    
public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/roles", HandleAsync)
        .WithName("Identity: Roles")
        .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> singInManager)
    {
        await singInManager.SignOutAsync();
        return Results.Ok();
    }
}

