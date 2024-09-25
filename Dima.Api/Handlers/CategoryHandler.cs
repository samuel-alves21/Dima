using Dima.Api.Data;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new Response<Category>(category);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception("falha ao criar a categoria");
        }
    }

    public Task<Response<Category>> CreateAsync(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category>> CreateAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Category>> CreateAsync(GetCategoryByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<Category>>> CreateAsync(GetAllCategoriesRequest request)
    {
        throw new NotImplementedException();
    }
}