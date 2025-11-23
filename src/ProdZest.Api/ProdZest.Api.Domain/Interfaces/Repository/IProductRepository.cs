using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository.Base;

namespace ProdZest.Api.Domain.Interfaces.Repository;
public interface IProductRepository : IRepositoryBase<Product>
{
    Task<PagedListDto<Product>> GetAllProductsAsync(ProductRequest requestDto);
}
