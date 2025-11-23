using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository.Base;

namespace ProdZest.Api.Domain.Interfaces.Repository;
public interface ICategoryRepository : IRepositoryBase<Category>
{
    Task<PagedListDto<Category>> GetAllCategoriesAsync(CategoryRequest requestDto);
}
