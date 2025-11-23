using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Category.List;
using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Service.Base;

namespace ProdZest.Api.Domain.Interfaces.Service;
public interface ICategoryService : IServiceBase<Category>
{
    Task<PagedListDto<CategoryResponseList>> GetAllCategoriesAsync(CategoryRequest requestDto);
}
