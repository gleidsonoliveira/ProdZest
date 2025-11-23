using ProdZest.Api.Data.Context;
using ProdZest.Api.Data.Repository.Base;
using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Dtos.Pagination.Helper;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Interfaces.Repository;

namespace ProdZest.Api.Data.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProdZestContext prodZestContext) : base(prodZestContext) { }

    public async Task<PagedListDto<Product>> GetAllProductsAsync(ProductRequest requestDto)
    {
        _ = requestDto ?? throw new ArgumentNullException(nameof(requestDto));

        IQueryable<Product> query = _prodZestContext.Product
            .Where(c => c.Active)
            .Select(c => new Product
            {
                Id = c.Id,
                Description = c.Description,
                UnitPrice = c.UnitPrice,
                GrossPrice = c.GrossPrice,
                StockQuantity = c.StockQuantity,
            }).OrderByDescending(c => c.Description);

        return await PaginatedListDto.CreateAsync(query, requestDto.PageNumber, requestDto.PageSize);
    }
}
