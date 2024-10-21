using Dima.Api.Common.Api;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/logout", HandleAsync)
        .WithName("Identity: Logout")
        .RequireAuthorization();

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user)
    {
        if (user == null || !user.Identity.IsAuthenticated) return Results.Unauthorized();

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity.FindAll(identity.RoleClaimType).Select(c => new
        {
            c.Issuer,
            c.OriginalIssuer,
            c.Value,
            c.ValueType
        });

        return TypedResults.Json(roles);
    }
}

