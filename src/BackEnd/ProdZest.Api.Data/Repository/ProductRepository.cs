using Microsoft.EntityFrameworkCore;
using ProdZest.Api.Data.Context;
using ProdZest.Api.Data.Repository.Base;
using ProdZest.Api.Domain.Dtos.Pagination;
using ProdZest.Api.Domain.Dtos.Pagination.Helper;
using ProdZest.Api.Domain.Dtos.Product;
using ProdZest.Api.Domain.Entities;
using ProdZest.Api.Domain.Enum;
using ProdZest.Api.Domain.Interfaces.Repository;

namespace ProdZest.Api.Data.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProdZestContext prodZestContext) : base(prodZestContext) { }

    public async Task<PagedListDto<Product>> GetAllProductsAsync(ProductRequest requestDto)
    {
        _ = requestDto ?? throw new ArgumentNullException(nameof(requestDto));

        IQueryable<Product> query = _prodZestContext.Product
            .Include(c => c.Category)
            .Where(c => c.Situation == Situation.Active)
            .Select(c => new Product
            {
                Id = c.Id,
                Description = c.Description,
                Category = new Category
                {
                    Id = c.Category.Id,
                    Description = c.Category.Description
                }
            }).OrderByDescending(c => c.Description);

        if (requestDto is not null)
        {
            if (!string.IsNullOrEmpty(requestDto.Description))
                query = query.Where(c => c.Description.ToLower().Trim().Contains(requestDto.Description.ToLower().Trim()));

            if (requestDto.Situation.GetHashCode() > 0)
                query = query.Where(c => c.Situation == requestDto.Situation);
        }

        return await PaginatedListDto.CreateAsync(query, requestDto.PageNumber, requestDto.PageSize);
    }
}
