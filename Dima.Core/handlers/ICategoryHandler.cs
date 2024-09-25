using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;

public interface ICategoryHandler
{
	Task<Response<Category?>> CreateAsync (CreateCategoryRequest request);
	Task<Response<Category?>> UpdateAsync (UpdateCategoryRequest request);
	Task<Response<Category?>> DeleteAsync (DeleteCategoryRequest request);
	Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
	Task<Response<List<Category>>> GetAllAsync (GetAllCategoriesRequest request);
}