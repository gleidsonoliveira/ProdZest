using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Category.List;
using ProdZest.Api.Domain.Dtos.Paginacao;
using ProdZest.Api.Domain.Dtos.Paginacao.Filter;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository.Base;

namespace ProdZest.Api.Domain.Interfaces.Repository;
public interface ICategoryRepository : IRepositoryBase<Category>
{
    Task<PagedResponse<IEnumerable<CategoryResponseList>>> GetAllCategoriesAsync(FiltroPaginacao filtroPaginacao, CategoryRequest requestDto);
}
