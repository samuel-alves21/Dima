using Dima.Core.Models;
using Dima.Core.Requests;
using Dima.Core.Responses;

public interface ICategoryHandler
{
	Task<Response<Category>> CreateAsync (CreateCategoryRequest request);
	Task<Response<Category>> CreateAsync (UpdateCategoryRequest request);
	Task<Response<Category>> CreateAsync (DeleteCategoryRequest request);
	Task<Response<Category>> CreateAsync (GetCategoryByIdRequest request);
	Task<Response<List<Category>>> CreateAsync (GetAllCategoriesRequest request);
}