using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Dima.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwaggerUI();
        app.UseSwagger();
        app.MapSwagger().RequireAuthorization();
    }
    public static void  UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

    }

    public static void d(this WebApplication app)
    {
        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("logout", async (SignInManager<User> singInManager) =>
            {
                await singInManager.SignOutAsync();
                return Results.Ok();
            })
            .RequireAuthorization();


        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapGet("/roles", (ClaimsPrincipal user) =>
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
            });

    }


}

