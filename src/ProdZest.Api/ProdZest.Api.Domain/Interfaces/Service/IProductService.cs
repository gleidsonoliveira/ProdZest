using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Dtos.Product.List;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Service.Base;

namespace ProdZest.Api.Domain.Interfaces.Service;
public interface IProductService : IServiceBase<Product>
{
    Task<PagedListDto<ProductResponseListDto>> GetAllProductsAsync(ProductRequest requestDto);
}
