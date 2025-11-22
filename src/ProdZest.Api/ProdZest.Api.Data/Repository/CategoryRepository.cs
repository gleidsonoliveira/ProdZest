using ProdZest.Api.Data.Context;
using ProdZest.Api.Data.Repository.Base;
using ProdZest.Api.Domain.Dtos.Category;
using ProdZest.Api.Domain.Dtos.Category.List;
using ProdZest.Api.Domain.Dtos.Paginacao;
using ProdZest.Api.Domain.Dtos.Paginacao.Filter;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;

namespace ProdZest.Api.Data.Repository;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProdZestContext prodZestContext) : base(prodZestContext)
    {
    }

    public Task<PagedResponse<IEnumerable<CategoryResponseList>>> GetAllCategoriesAsync(FiltroPaginacao filtroPaginacao, CategoryRequest requestDto)
    {
       
    }
}
