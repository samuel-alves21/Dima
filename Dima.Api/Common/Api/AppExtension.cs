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
}

