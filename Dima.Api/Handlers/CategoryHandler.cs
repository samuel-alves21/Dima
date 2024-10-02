using Dima.Api.Data;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
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

            return new Response<Category?>(category, 201, "categoria criada com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "N�o foi poss�vel criar a categoria");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null) return new Response<Category?>(null, 400, "Categoria n�o encontarda");

            category.Title = request.Title;
            category.Description = request.Description;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 200, "categoria atualizada com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "N�o foi poss�vel alterar a categoria");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null) return new Response<Category?>(null, 404, "Categoria n�o encontarda");

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 200, "categoria excluida com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 500, "N�o foi poss�vel excluir a categoria");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync((x) => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null) return new Response<Category?>(null, 404, "Categoria n�o encontarda");

            return new Response<Category?>(category);
        }
        catch
        {
            return new Response<Category?>(null, 500, "N�o foi poss�vel encontrar a categoria");
        }
    }

    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var query = context.Categories.AsNoTracking().Where(x => x.UserId == request.UserId);

            var categories = await query
                .Skip(request.PageSize * request.PageNumber)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Category>>(categories, count, Configuration.DefaultPageSize, Configuration.DefaultPageNumber);
        }
        catch
        {
            return new PagedResponse<List<Category>>(null, 500, "n�o foi poss�vel encontrar as categorias");
        }
    }
}