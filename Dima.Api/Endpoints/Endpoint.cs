using Dima.Api.Common.Api;
using Dima.Api.Endpoints.Categories;

namespace Dima.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("v1/categories")
            .WithTags("categories")
            //.RequireAuthorization()
            .MapEndpoints<CreateCategoryEndpoint>()
            .MapEndpoints<UpdateCategoryEndpoint>()
            .MapEndpoints<DeleteCategoryEndpoint>()
            .MapEndpoints<GetCategoryByIdEndpoint>()
            .MapEndpoints<GetAllCategoriesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoints<TEndpoint>(this IEndpointRouteBuilder app)  where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}