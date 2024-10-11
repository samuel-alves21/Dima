using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.AddDbContext<AppDbContext>(options =>
{ 
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((x) =>
{
    x.CustomSchemaIds((n) => n.FullName);
});

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();
builder.Services.AddAuthorization();

builder.Services.AddTransient<CategoryHandler>();
builder.Services.AddTransient<TransactionHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerUI();
app.UseSwagger();

app.MapGet("/", () => new { Message = "Ok" }); 
app.MapEndpoints();
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

app.Run();  
